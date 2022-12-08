using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Models;
using Microsoft.EntityFrameworkCore;

namespace WebHostel.DAL.Repositories
{
    public class HostelRepository : IBaseRepository<HostelViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public HostelRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(HostelViewModel Entity)
        {
                dbase
               .Database
               .ExecuteSqlRaw
               ($"call CreateHostel('{Entity.title}', '{Entity.info}', '{Entity.location}')");
                return true;
        }

        public bool Delete(HostelViewModel Entity)
        {
            var _hostel = new Hostel
            {
                id = Entity.id,
                title = Entity.title,
                location = Entity.location
            };

            dbase.Hostel.Remove(_hostel);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(HostelViewModel Entity, int id)
        {
            var _hostel = dbase.Hostel.Where(h => h.id == id).AsNoTracking().FirstOrDefault();
            var _hostel_info = dbase.Hostel_info.Where(hi => hi.hostel_id == _hostel.id).AsNoTracking().FirstOrDefault();

            _hostel.title = Entity.title;
            _hostel.location = Entity.location;
            _hostel_info.hostel_id = Entity.id;
            _hostel_info.info = Entity.info;

            dbase.Hostel.Update(_hostel);
            dbase.SaveChanges();
            dbase.Hostel_info.Update(_hostel_info);
            dbase.SaveChanges();

            return true;
        }

        public HostelViewModel Get(string unique_value)
        {
            return (from h in dbase.Hostel
                   join hi in dbase.Hostel_info
                   on h.id equals hi.hostel_id
                   where h.title == unique_value
                   select new HostelViewModel
                   {
                       id = h.id,
                       title = h.title,
                       location = h.location,
                       info = hi.info
                   }).FirstOrDefault();
        }

        public HostelViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HostelViewModel> GetAll()
        {
            return (from h in dbase.Hostel
                    join hi in dbase.Hostel_info
                    on h.id equals hi.hostel_id
                    select new HostelViewModel
                    {
                        id = h.id,
                        title = h.title,
                        location = h.location,
                        info = hi.info
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            return (from h in dbase.Hostel
                    where h.title == unique_value
                    select h.id).FirstOrDefault();
        }
    }
}
