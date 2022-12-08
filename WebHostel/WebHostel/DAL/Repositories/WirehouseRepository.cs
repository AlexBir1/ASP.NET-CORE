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
    public class WirehouseRepository : IBaseRepository<WirehouseViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public WirehouseRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(WirehouseViewModel Entity)
        {
            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.title)
                .FirstOrDefault();

            var wirehouse = new Wirehouse
            {
                hostel_id = hostel.id,
                title = Entity.title,
                maxProducts = Entity.maxProducts
            };

            dbase.Add(wirehouse);
            dbase.SaveChanges();

            return true;
        }

        public bool Delete(WirehouseViewModel Entity)
        {
            var wirehouse = dbase.Wirehouse.
                Where(w => w.title == Entity.title).AsNoTracking()
                .FirstOrDefault();

            dbase.Remove(wirehouse);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(WirehouseViewModel Entity, int id)
        {
            var wirehouse = dbase.Wirehouse.
                Where(w => w.hostel_id == id).AsNoTracking()
                .FirstOrDefault();

            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.title)
                .FirstOrDefault();

            wirehouse = new Wirehouse
            {
                hostel_id = hostel.id,
                title = Entity.title,
                maxProducts = Entity.maxProducts
            };

            dbase.Update(wirehouse);
            dbase.SaveChanges();

            return true;
        }

        public WirehouseViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public WirehouseViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WirehouseViewModel> GetAll()
        {
            return (from w in dbase.Wirehouse
                    join h in dbase.Hostel
                    on w.hostel_id equals h.id
                    select new WirehouseViewModel
                    {
                        id = w.hostel_id,
                        hostel_name = h.title,
                        title = w.title,
                        maxProducts = w.maxProducts
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
