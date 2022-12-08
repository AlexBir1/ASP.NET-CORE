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
    public class EmployeesRepository : IBaseRepository<EmployeesViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public EmployeesRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(EmployeesViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call CreateEmployee(" +
               $"'{Entity.fullname}', " +
               $"'{Entity.phone}', " +
               $"'{(int)Entity.rank}', " +
               $"'{Entity.hostel_name}', " +
               $"'{Entity.login}', " +
               $"'{Entity.password}', " +
               $"'{(int)Entity.status}')");
            return true;
        }

        public bool Delete(EmployeesViewModel Entity)
        {
            var employee = dbase.Employees
                .Where(e => e.id == Entity.id).AsNoTracking().FirstOrDefault();
            dbase.Remove(employee);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(EmployeesViewModel Entity, int id)
        {
            var employee = dbase.Employees
                .Where(e => e.id == id).AsNoTracking().FirstOrDefault();
            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.hostel_name).FirstOrDefault();
            var profile = dbase.Profiles
                .Where(p => p.id == employee.profiles_id).AsNoTracking().FirstOrDefault();

            employee.fullname = Entity.fullname;
            employee.phone = Entity.phone;
            employee.hostel_id = hostel.id;
            employee.rank = (int)Entity.status;
            profile.login = Entity.login;
            profile.passw = Entity.password;

            dbase.Update(employee);
            dbase.SaveChanges();
            dbase.Update(profile);
            dbase.SaveChanges();

            return true;
        }

        public EmployeesViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public EmployeesViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeesViewModel> GetAll()
        {
            return (from e in dbase.Employees
                    join h in dbase.Hostel
                    on e.hostel_id equals h.id
                    join p in dbase.Profiles
                    on e.profiles_id equals p.id
                    select new EmployeesViewModel
                    {
                        id = e.id,
                        fullname = e.fullname,
                        phone = e.phone,
                        rank = (EmployeeRanks)e.rank,
                        hostel_name = h.title,
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
