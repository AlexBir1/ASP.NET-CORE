using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Domain.Enum;
using WebHostel.Models;

namespace WebHostel.DAL.Repositories
{
    public class Wirehouse_employeesRepository : IBaseRepository<Wirehouse_employeesViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public Wirehouse_employeesRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(Wirehouse_employeesViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call CreateWEmployee(" +
               $"'{Entity.fullname}', " +
               $"'{Entity.phone}', " +
               $"'{(int)Entity.rank}', " +
               $"'{Entity.wirehouse_name}', " +
               $"'{Entity.login}', " +
               $"'{Entity.password}', " +
               $"'{(int)Entity.status}')");
            return true;
        }

        public bool Delete(Wirehouse_employeesViewModel Entity)
        {
            var wEmployee = dbase.Wirehouse_employees
                .Where(we => we.id == Entity.id)
                .FirstOrDefault();

            dbase.Remove(wEmployee);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(Wirehouse_employeesViewModel Entity, int id)
        {
            var wemployee = dbase.Wirehouse_employees
                .Where(ce => ce.id == id).AsNoTracking().FirstOrDefault();
            var wirehouse = dbase.Cafe
                .Where(w => w.title == Entity.wirehouse_name).FirstOrDefault();
            var profile = dbase.Profiles
                .Where(p => p.id == wemployee.profiles_id).AsNoTracking().FirstOrDefault();

            wemployee.fullname = Entity.fullname;
            wemployee.phone = Entity.phone;
            wemployee.wirehouse_hostel_id = wirehouse.hostel_id;
            wemployee.rank = (int)Entity.status;
            profile.login = Entity.login;
            profile.passw = Entity.password;

            dbase.Update(wemployee);
            dbase.SaveChanges();
            dbase.Update(profile);
            dbase.SaveChanges();

            return true;
        }

        public Wirehouse_employeesViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public Wirehouse_employeesViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Wirehouse_employeesViewModel> GetAll()
        {
            return (from we in dbase.Wirehouse_employees
                    join w in dbase.Wirehouse
                    on we.wirehouse_hostel_id equals w.hostel_id
                    join p in dbase.Profiles
                    on we.profiles_id equals p.id
                    select new Wirehouse_employeesViewModel
                    {
                        id = we.id,
                        fullname = we.fullname,
                        phone = we.phone,
                        rank = (WEmployeeRanks)we.rank,
                        wirehouse_name = w.title,
                        login = p.login,
                        password = p.passw,
                        status = (UserStatus)p.status
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
