using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Enum;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Implementations
{
    public class AdminsRepository : IAdminsInterface
    {
        private readonly AppDbContext _db;

        public AdminsRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IBaseResponse<Admins>> Create(Admins EntityToCreate)
        {
            try
            {
                _db.Admins.Add(EntityToCreate);
                await _db.SaveChangesAsync();

                return new DBResponse<Admins>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Admins>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Admins>> Delete(Admins EntityToDelete)
        {
            try
            {
                _db.Admins.Remove(EntityToDelete);
                await _db.SaveChangesAsync();

                return new DBResponse<Admins>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Admins>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Admins>> Edit(Admins EntityToEdit)
        {
            try
            {
                _db.Admins.Update(EntityToEdit);
                await _db.SaveChangesAsync();

                return new DBResponse<Admins>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Admins>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<ClaimsIdentity>> FindAndAuthenticate(string Login, string Password)
        {
            try
            {
                var student = await _db.Admins
                    .FirstAsync(x => x.Login == Login && x.Password == Password);

                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, student.Fullname),
                new Claim(ClaimTypes.Email, student.Login),
                new Claim(ClaimTypes.Sid, student.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, UserStatus.Student.ToString())
            };
                return new DBResponse<ClaimsIdentity>
                {
                    Data = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType),
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Invalid login or password",
                    IsSuccessful = false
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Admins>>> GetAll()
        {
            try
            {
                var admins = await _db.Admins.ToListAsync();

                return new DBResponse<IEnumerable<Admins>>
                {
                    IsSuccessful = true,
                    Data = admins
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Admins>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Admins>> GetById(int Id)
        {
            try
            {
                var admin = await _db.Admins.FirstAsync(x => x.Id == Id);

                return new DBResponse<Admins>
                {
                    IsSuccessful = true,
                    Data = admin
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Admins>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }
    }
}
