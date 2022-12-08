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
    public class ServicesRepository : IBaseRepository<ServicesViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public ServicesRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(ServicesViewModel Entity)
        {
            dbase
            .Database
            .ExecuteSqlRaw
            ($"call AddBooking(" +
            $"'{Entity.title}', " +
            $"'{Entity.info}', " +
            $"'{Entity.cost}', " +
            $"'{Entity.isDriving}', " +
            $"'{Entity.employee_rank}', " +
            $"'{Entity.hostel_name}')");
            return true;
        }

        public bool Delete(ServicesViewModel Entity)
        {
            var Service = dbase.Services
                .Where(s => s.id == Entity.id)
                .FirstOrDefault();
            dbase.Remove(Service);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(ServicesViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public ServicesViewModel Get(string unique_value)
        {
            return (from s in dbase.Services
                    join si in dbase.Services_info
                    on s.id equals si.services_id
                    join h in dbase.Hostel
                    on s.hostel_id equals h.id
                    where s.title == unique_value
                    select new ServicesViewModel
                    {
                        id = s.id,
                        title = s.title,
                        info = si.info,
                        cost = s.cost,
                        employee_rank = s.employee_rank,
                        isDriving = s.isDriving,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public ServicesViewModel Get(string unique_value, string _hostel_name)
        {
            return (from s in dbase.Services
                    join si in dbase.Services_info
                    on s.id equals si.services_id
                    join h in dbase.Hostel
                    on s.hostel_id equals h.id
                    where s.title == unique_value
                    && h.title == _hostel_name
                    select new ServicesViewModel
                    {
                        id = s.id,
                        title = s.title,
                        info = si.info,
                        cost = s.cost,
                        employee_rank = s.employee_rank,
                        isDriving = s.isDriving,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public IEnumerable<ServicesViewModel> GetAll()
        {
            return (from s in dbase.Services
                    join i in dbase.Services_info
                    on s.id equals i.services_id
                    join h in dbase.Hostel
                    on s.hostel_id equals h.id
                    select new ServicesViewModel
                    {
                        id = s.id,
                        title = s.title,
                        info = i.info,
                        cost = s.cost,
                        employee_rank = s.employee_rank,
                        isDriving = s.isDriving,
                        hostel_name = h.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
