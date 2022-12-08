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
    public class Cafe_employeesRepository : IBaseRepository<Cafe_employeesViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public Cafe_employeesRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(Cafe_employeesViewModel Entity)
        {
               dbase
               .Database
               .ExecuteSqlRaw
               ($"call CreateCEmployee(" +
               $"'{Entity.fullname}', " +
               $"'{Entity.phone}', " +
               $"'{(int)Entity.rank}', " +
               $"'{Entity.cafe_name}', " +
               $"'{Entity.login}', " +
               $"'{Entity.password}', " +
               $"'{(int)Entity.status}')");
                return true;
        }

        public bool Delete(Cafe_employeesViewModel Entity)
        {
            var cemployee = dbase.Cafe_employees
                .Where(ce=>ce.id == Entity.id).AsNoTracking().FirstOrDefault();
            dbase.Remove(cemployee);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(Cafe_employeesViewModel Entity, int id)
        {
            var cemployee = dbase.Cafe_employees
                .Where(ce => ce.id == id).AsNoTracking().FirstOrDefault();
            var cafe = dbase.Cafe
                .Where(ce => ce.title == Entity.cafe_name).FirstOrDefault();
            var profile = dbase.Profiles
                .Where(p => p.id == cemployee.profiles_id).AsNoTracking().FirstOrDefault();

            cemployee.fullname = Entity.fullname;
            cemployee.phone = Entity.phone;
            cemployee.cafe_hostel_id = cafe.hostel_id;
            cemployee.rank = (int)Entity.rank;
            profile.login = Entity.login;
            profile.passw = Entity.password;

            dbase.Update(cemployee);
            dbase.SaveChanges();
            dbase.Update(profile);
            dbase.SaveChanges();

            return true;
        }

        public Cafe_employeesViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public Cafe_employeesViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cafe_employeesViewModel> GetAll()
        {
            return (from ce in dbase.Cafe_employees
                    join c in dbase.Cafe
                    on ce.cafe_hostel_id equals c.hostel_id
                    join p in dbase.Profiles
                    on ce.profiles_id equals p.id
                    select new Cafe_employeesViewModel
                    {
                        id = ce.id,
                        fullname = ce.fullname,
                        phone = ce.phone,
                        rank = (CEmployeeRanks)ce.rank,
                        cafe_name = c.title,
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
