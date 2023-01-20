
using elfbar_shop.Domain.Entities;
using elfbar_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using elfbar_shop.Domain.Response;
using Microsoft.AspNetCore.Mvc;
using elfbar_shop.DAL.Services.Interfaces;

namespace elfbar_shop.DAL.Services.Implements
{
    public class ProfilesService : IProfilesService
    {
        private readonly AppDBContext dbase;

        public ProfilesService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<ProfilesViewModel> CreateProfile(ProfilesViewModel _profile)
        {
            var Profile = new Profiles
            {
                id = 0,
                alias = _profile.alias,
                login = _profile.login,
                passw = _profile.passw
            };
            try
            {
                dbase.Profiles.Add(Profile);
                dbase.SaveChanges();

                return new DBResponse<ProfilesViewModel>
                {
                    Description = "SUCCESS!",
                    StatusCode = StatusCodes.OK
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<ProfilesViewModel>
                {
                    Description = $"ERROR: {ex.Message}",
                };
            }
        }

        public IBaseResponse<ProfilesViewModel> DeleteProfile(ProfilesViewModel _profile)
        {
            var Profile = new Profiles
            {
                id = _profile.id,
                alias = _profile.alias,
                login = _profile.login,
                passw = _profile.passw
            };
            try
            {
                dbase.Profiles.Remove(Profile);
                dbase.SaveChanges();

                if (dbase.Profiles.Where(p => p.id == _profile.id).AsNoTracking().FirstOrDefault() == null)
                    return new DBResponse<ProfilesViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<ProfilesViewModel>
                {
                    Description = "ERROR WHILE DELETING!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProfilesViewModel>
                {
                    Description = $"ERROR: {ex.Message}",
                };
            }
        }

        public IBaseResponse<ProfilesViewModel> EditProfile(ProfilesViewModel _profile)
        {
            var Profile = new Profiles
            {
                id = _profile.id,
                alias = _profile.alias,
                login = _profile.login,
                passw = _profile.passw
            };

            try
            {
                dbase.Profiles.Update(Profile);
                dbase.SaveChanges();

                if (dbase.Profiles.Where(p => p.id == _profile.id).AsNoTracking().FirstOrDefault().id == Profile.id)
                    return new DBResponse<ProfilesViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<ProfilesViewModel>
                {
                    Description = "ERROR WHILE DELETING!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProfilesViewModel>
                {
                    Description = $"ERROR: {ex.Message}",
                };
            }
        }

        public IBaseResponse<IEnumerable<ProfilesViewModel>> GetProfiles()
        {
            try
            {
                var Profiles = (from p in dbase.Profiles
                                select new ProfilesViewModel
                                {
                                    id = p.id,
                                    alias = p.alias,
                                    login = p.login,
                                    passw = p.passw
                                }).ToList();
                dbase.Dispose();
                if (Profiles.Count != 0)
                    return new DBResponse<IEnumerable<ProfilesViewModel>>
                    {
                        Data = Profiles,
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<IEnumerable<ProfilesViewModel>>
                {
                    Description = "Empty list",
                    StatusCode = StatusCodes.DataIsEmpty
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ProfilesViewModel>>
                {
                    Description = $"ERROR: {ex.Message}",
                };
            }
        }

        public IBaseResponse<ClaimsIdentity> Log_in(LoginViewModel _profile)
        {
            var User = dbase.Profiles
                .Where(p => p.login == _profile.login)
                .AsNoTracking().FirstOrDefault();
            if (User == null)
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Немає такого тіпа в команді!",
                    StatusCode = StatusCodes.DataIsEmpty
                };
            else if (User.passw != _profile.password)
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Перевірь логін та пароль!",
                    StatusCode = StatusCodes.InternalError
                };
            else
            {
                var Response = Authenticate(new ProfilesViewModel
                {
                    id = User.id,
                    alias = User.alias,
                    login = User.login
                });
                return new DBResponse<ClaimsIdentity>
                {
                    Data = Response,
                    StatusCode = StatusCodes.OK
                };
            }
        }

        private ClaimsIdentity Authenticate(ProfilesViewModel _customer)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _customer.alias),
                new Claim(ClaimTypes.Email, _customer.login),
                new Claim(ClaimTypes.Sid,_customer.id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "admin")
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
