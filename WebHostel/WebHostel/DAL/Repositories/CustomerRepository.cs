using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Domain.Enum;
using WebHostel.Models;

namespace WebHostel.DAL.Repositories
{
    public class CustomersRepository : IBaseRepository<CustomersViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public CustomersRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(CustomersViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call CreateCustomer('" +
               $"{Entity.fullname}', " +
               $"'{Entity.phone}', " +
               $"'{Entity.hostel_name}', " +
               $"'{Entity.login}', " +
               $"'{Entity.password}', " +
               $"'{(int)UserStatus.customer}')");

            return true;
        }

        public bool Delete(CustomersViewModel Entity)
        {
            var _customer = dbase.Customers
                .Where(c => c.id == Entity.id).AsNoTracking()
                .FirstOrDefault();

            dbase.Remove(_customer);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(CustomersViewModel Entity, int id)
        {
            var new_customer = dbase.Customers
                .Where(c=>c.id == Entity.id).AsNoTracking().FirstOrDefault();
            var new_profile = dbase.Profiles
                .Where(p => p.id == new_customer.profiles_id).AsNoTracking().FirstOrDefault();
            new_customer.fullname = Entity.fullname;
            new_customer.phone = Entity.phone;
            new_customer.hostel_name = Entity.hostel_name;
            new_profile.login = Entity.login;
            new_profile.passw = Entity.password;

            dbase.Update(new_customer);
            dbase.SaveChanges();
            dbase.Update(new_profile);
            dbase.SaveChanges();
            return true;
        }

        public CustomersViewModel Get(string unique_value)
        {
            return (from c in dbase.Customers
                    join p in dbase.Profiles
                    on c.profiles_id equals p.id
                    where c.phone == unique_value
                    select new CustomersViewModel
                    {
                        id = c.id,
                        fullname = c.fullname,
                        phone = c.phone,
                        hostel_name = c.hostel_name,
                        login = p.login,
                        password = p.passw,
                        status = (UserStatus)p.status
                    }).FirstOrDefault();
        }

        public CustomersViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomersViewModel> GetAll()
        {
            var cust = (from c in dbase.Customers 
                    join p in dbase.Profiles 
                    on c.profiles_id equals p.id 
                    select new CustomersViewModel 
                    { 
                        id = c.id,
                        fullname = c.fullname,
                        phone = c.phone,
                        hostel_name = c.hostel_name,
                        login = p.login,
                        password = p.passw,
                        status = (UserStatus)p.status
                    }).ToList();
            return cust;
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
