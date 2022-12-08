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
    public class Services_historyRepository : IBaseRepository<Services_historyViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public Services_historyRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(Services_historyViewModel Entity)
        {
            dbase
            .Database
            .ExecuteSqlRaw
            ($"call SelectService('{Entity.stitle}', '{Entity.customer_num}', '{Entity.hostel_name}')");
            return true;
        }

        public bool Delete(Services_historyViewModel Entity)
        {
            var SinH = dbase.Services_history
                .Where(sh => sh.id == Entity.id)
                .FirstOrDefault();
            dbase.Remove(SinH);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(Services_historyViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public Services_historyViewModel Get(string unique_value)
        {
            return (from s in dbase.Services_history
                    join h in dbase.Hostel
                    on s.hostel_id equals h.id
                    where s.customer_num == unique_value
                    select new Services_historyViewModel
                    {
                        id = s.id,
                        stitle = s.stitle,
                        service_date = s.service_date,
                        cost = s.cost,
                        customer_num = s.customer_num,
                        employee_num = s.employee_num,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public Services_historyViewModel Get(string unique_value, string _hostel_name)
        {
            return (from s in dbase.Services_history
                    join h in dbase.Hostel
                    on s.hostel_id equals h.id
                    where s.customer_num == unique_value &&
                    h.title == _hostel_name
                    select new Services_historyViewModel
                    {
                        id = s.id,
                        stitle = s.stitle,
                        service_date = s.service_date,
                        cost = s.cost,
                        customer_num = s.customer_num,
                        employee_num = s.employee_num,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public IEnumerable<Services_historyViewModel> GetAll()
        {
            return (from s in dbase.Services_history
                    join h in dbase.Hostel
                    on s.hostel_id equals h.id
                    select new Services_historyViewModel
                    {
                        id = s.id,
                        stitle = s.stitle,
                        service_date = s.service_date,
                        cost = s.cost,
                        customer_num = s.customer_num,
                        employee_num = s.employee_num,
                        hostel_name = h.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
