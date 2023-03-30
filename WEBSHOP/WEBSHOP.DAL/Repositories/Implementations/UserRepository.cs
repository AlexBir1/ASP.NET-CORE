using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.Enums;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Implementations
{
    public class UserRepository : IUserInterface
    {
        private readonly AppDBContext _db;

        public UserRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool Create(UserViewModel Entity)
        {
            if (Entity.MyUnit.Id == 0)
            {
                _db.User.Add(new User
                {
                    Fullname = Entity.Fullname,
                    Phone = Entity.Phone,
                    Status = (int)Entity.Status,
                    ShippingAddress = Entity.ShippingAddress,
                    Login = Entity.Login,
                    Password = Entity.Password,
                });
                _db.SaveChanges();
                return true;
            }
            _db.User.Add(new User
            {
                Fullname = Entity.Fullname,
                Phone = Entity.Phone,
                Status = (int)Entity.Status,
                ShippingAddress = Entity.ShippingAddress,
                Login = Entity.Login,
                Password = Entity.Password,
                Unit_Id = Entity.MyUnit.Id
            });
            _db.SaveChanges();
            return true;
        }

        public bool Delete(UserViewModel Entity)
        {
            _db.User.Remove(new User
            {
                Id = Entity.Id,
                Fullname = Entity.Fullname,
                Phone = Entity.Phone,
                Status = (int)Entity.Status,
                ShippingAddress = Entity.ShippingAddress,
                Login = Entity.Login,
                Password = Entity.Password,
                Unit_Id = Entity.MyUnit.Id
            });
            _db.SaveChanges();
            return true;
        }

        public bool Edit(UserViewModel Entity)
        {
            _db.User.Update(new User
            {
                Id = Entity.Id,
                Fullname = Entity.Fullname,
                Phone = Entity.Phone,
                Status = (int)Entity.Status,
                ShippingAddress = Entity.ShippingAddress,
                Login = Entity.Login,
                Password = Entity.Password,
                Unit_Id = Entity.MyUnit.Id
            });
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            List<UserViewModel> Customers;
            List<UserViewModel> Employees;
            Employees = await (from u in _db.User
                          join un in _db.Unit on u.Unit_Id equals un.Id
                          select new UserViewModel
                          {
                              Id = u.Id,
                              Fullname = u.Fullname,
                              Phone = u.Phone,
                              ShippingAddress = u.ShippingAddress,
                              Status = (UserStatus)u.Status,
                              Login = u.Login,
                              Password = u.Password,
                              MyUnit = new UnitViewModel
                              {
                                  Id = un.Id,
                                  Title = un.Title,
                                  Address = un.Address
                              }
                          }).ToListAsync();
            Customers = await (from u in _db.User
                               where u.Unit_Id == null || u.Unit_Id == 0
                               select new UserViewModel
                               {
                                   Id = u.Id,
                                   Fullname = u.Fullname,
                                   Phone = u.Phone,
                                   ShippingAddress = u.ShippingAddress,
                                   Status = (UserStatus)u.Status,
                                   Login = u.Login,
                                   Password = u.Password
                                   
                               }).ToListAsync();
            Customers.AddRange(Employees);
            return Customers;
        }

        public async Task<UserViewModel> GetById(int Id)
        {
            UserViewModel Customer;
            UserViewModel Employee;
            Employee = await (from u in _db.User
                          join un in _db.Unit on u.Unit_Id equals un.Id
                          where u.Id == Id
                          select new UserViewModel
                          {
                              Id = u.Id,
                              Fullname = u.Fullname,
                              Phone = u.Phone,
                              ShippingAddress = u.ShippingAddress,
                              Status = (UserStatus)u.Status,
                              Login = u.Login,
                              Password = u.Password,
                              MyUnit = new UnitViewModel
                              {
                                  Id = un.Id,
                                  Title = un.Title,
                                  Address = un.Address
                              }
                          }).FirstOrDefaultAsync();

            Customer = await (from u in _db.User
                            where u.Unit_Id == null && u.Id == Id
                            select new UserViewModel
                            {
                                Id = u.Id,
                                Fullname = u.Fullname,
                                Phone = u.Phone,
                                ShippingAddress = u.ShippingAddress,
                                Status = (UserStatus)u.Status,
                                Login = u.Login,
                                Password = u.Password

                            }).FirstOrDefaultAsync();

            if(Customer != null)
                return Customer;

            else
                return Employee;
        }

        public ClaimsIdentity AuthenticateUser(UserViewModel User)
        {
            var Client = _db.User.Where(u => u.Login == User.Login).FirstOrDefault();
            var UserST = (UserStatus)Client.Status;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, Client.Phone),
                new Claim(ClaimTypes.Email, Client.Login),
                new Claim(ClaimTypes.Sid, Client.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, UserST.ToString())
            };
            var NewClaimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return NewClaimsIdentity;
        }

        public void GetDataForCUPartials(ref List<UnitViewModel> _locallyCreatedUnitList)
        {
            _locallyCreatedUnitList = (from U in _db.Unit
                                       select new UnitViewModel
                                       {
                                           Id = U.Id,
                                           Title = U.Title
                                       }).ToList();
        }
    }
}
