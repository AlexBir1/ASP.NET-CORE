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
    public class ChecksHistoryRepository : IBaseRepository<Checks_historyViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public ChecksHistoryRepository(ApplicationDBContext dbc)
        {
            dbase = dbc;
        }

        public bool Create(Checks_historyViewModel Entity)
        {
            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.hostel_name)
                .FirstOrDefault();
            var _Checks_history = new Checks_history
            {
                checkin_date = Entity.checkin_date,
                checkout_date = Entity.checkout_date,
                cost = Entity.cost,
                customer_phone = Entity.customer_phone,
                hostel_id = hostel.id,
                id = Entity.id,
                roomNum = Entity.roomNum,
                roomRank = Entity.roomRank,
                wasBooked = Entity.wasBooked,
                wasPrivate = Entity.wasPrivate
            };

            dbase.Add(_Checks_history);
            dbase.SaveChanges();
            
            return true;
        }

        public bool Delete(Checks_historyViewModel Entity)
        {
            var _Checks_history = dbase.Checks_history
                .Where(chs => chs.id == Entity.id).AsNoTracking()
                .FirstOrDefault();
            dbase.Remove(_Checks_history);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(Checks_historyViewModel Entity, int id)
        {
            var _Checks_history = dbase.Checks_history
                .Where(chs => chs.id == id).AsNoTracking()
                .FirstOrDefault();

            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.hostel_name)
                .FirstOrDefault();

            dbase.Update(new Checks_history
            {
                checkin_date = Entity.checkin_date,
                checkout_date = Entity.checkout_date,
                cost = Entity.cost,
                customer_phone = Entity.customer_phone,
                hostel_id = hostel.id,
                id = Entity.id,
                roomNum = Entity.roomNum,
                roomRank = Entity.roomRank,
                wasBooked = Entity.wasBooked,
                wasPrivate = Entity.wasPrivate
            });
            dbase.SaveChanges();
            return true;
        }

        public Checks_historyViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public Checks_historyViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Checks_historyViewModel> GetAll()
        {
            return (from ch in dbase.Checks_history
                    join h in dbase.Hostel
                    on ch.hostel_id equals h.id
                    select new Checks_historyViewModel
                    {
                        checkin_date = ch.checkin_date,
                        checkout_date = ch.checkout_date,
                        cost = ch.cost,
                        customer_phone = ch.customer_phone,
                        hostel_name = h.title,
                        id = ch.id,
                        roomNum = ch.roomNum,
                        roomRank = ch.roomRank,
                        wasBooked = ch.wasBooked,
                        wasPrivate = ch.wasPrivate
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
