using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Models;

namespace WorkerService1
{
    public class ChecksRepository : IBaseRepository<ChecksViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public ChecksRepository(ApplicationDBContext db)
        {
            dbase = db;
        }
        public bool Create(ChecksViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call SelectRoom(" +
               $"'{Entity.rooms_num}', " +
               $"'{Entity.customer_num}', " +
               $"'{Entity.checkout_date.ToShortDateString()}, " +
               $"'{Entity.isBooked}', " +
               $"'{Entity.isPrivate}')");
            return true;
        }

        public bool Delete(ChecksViewModel Entity)
        {
            var check = dbase.Checks.Where(c => c.id == Entity.id);

            dbase.Remove(check);
            dbase.SaveChanges();
            
            return true;
        }

        public bool Edit(ChecksViewModel Entity, int id)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call CheckEdit('{Entity.customer_num}', '{Entity.rooms_num}', '{Entity.checkout_date}')");
            return true;
        }

        public ChecksViewModel Get(string unique_value)
        {
            return (from c in dbase.Checks
                    join cs in dbase.Customers
                    on c.customers_id equals cs.id
                    join rm in dbase.Rooms
                    on c.rooms_id equals rm.id
                    where rm.num == Int32.Parse(unique_value)
                    select new ChecksViewModel
                    {
                        id = c.id,
                        checkin_date = c.checkin_date,
                        checkout_date = c.checkout_date,
                        rooms_num = rm.num,
                        customer_num = cs.phone,
                        isBooked = c.isBooked,
                        isPrivate = c.isPrivate
                    }).FirstOrDefault();
        }

        public ChecksViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChecksViewModel> GetAll()
        {
            return (from c in dbase.Checks
                    join cs in dbase.Customers
                    on c.customers_id equals cs.id
                    join rm in dbase.Rooms
                    on c.rooms_id equals rm.id
                    select new ChecksViewModel
                    {
                        id = c.id,
                        checkin_date = c.checkin_date,
                        checkout_date = c.checkout_date,
                        rooms_num = rm.num,
                        customer_num = cs.phone,
                        isBooked = c.isBooked,
                        isPrivate = c.isPrivate
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
        public bool CheckExpire()
        {
            dbase.Database.ExecuteSqlRaw("call CheckExpire()");
            Thread.Sleep(10000);
            return true;
        }
    }
}
