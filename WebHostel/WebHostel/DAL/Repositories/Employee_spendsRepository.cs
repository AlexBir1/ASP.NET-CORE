using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Models;

namespace WebHostel.DAL.Repositories
{
    public class Employee_spendsRepository : IBaseRepository<Employee_spendsViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public Employee_spendsRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(Employee_spendsViewModel Entity)
        {
            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.hostel_name)
                .FirstOrDefault();

            var emSpends = new Employee_spends
            {
                id = Entity.id,
                countofOperations = Entity.countofOperations,
                sdate = Entity.periodStart_date,
                fdate = Entity.periodEnd_date,
                hostel_id = hostel.id,
                payment = Entity.payment,
                employee_phone = Entity.employee_phone
            };

            dbase.Add(emSpends);
            dbase.SaveChanges();

            return true;
        }

        public bool Delete(Employee_spendsViewModel Entity)
        {
            dbase.Remove(dbase.Employee_spends
                .Where(e => e.id == Entity.id).AsNoTracking()
                .FirstOrDefault());
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(Employee_spendsViewModel Entity, int id)
        {
            var emSpends = dbase.Employee_spends
                .Where(e => e.id == id).AsNoTracking()
                .FirstOrDefault();

            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.hostel_name)
                .FirstOrDefault();

            emSpends.id = Entity.id;
            emSpends.countofOperations = Entity.countofOperations;
            emSpends.employee_phone = Entity.employee_phone;
            emSpends.sdate = Entity.periodStart_date;
            emSpends.fdate = Entity.periodEnd_date;
            emSpends.payment = Entity.payment;
            emSpends.hostel_id = hostel.id;

            dbase.Update(emSpends);
            dbase.SaveChanges();

            return true;
        }

        public Employee_spendsViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public Employee_spendsViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee_spendsViewModel> GetAll()
        {
            return (from e in dbase.Employee_spends
                    join h in dbase.Hostel
                    on e.hostel_id equals h.id
                    select new Employee_spendsViewModel
                    {
                        id = e.id,
                        countofOperations = e.countofOperations,
                        periodStart_date = e.sdate,
                        periodEnd_date = e.fdate,
                        payment = e.payment,
                        employee_phone = e.employee_phone,
                        hostel_name = h.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
