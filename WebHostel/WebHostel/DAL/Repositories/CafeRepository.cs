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
    public class CafeRepository : IBaseRepository<CafeViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public CafeRepository(ApplicationDBContext dbc)
        {
            dbase = dbc;
        }

        public bool Create(CafeViewModel Entity)
        {
            dbase.
                Database.
                ExecuteSqlRaw($"call CreateCafe(" +
                $"'{Entity.hostel_name}', " +
                $"'{Entity.title}')");

            return true;
        }

        public bool Delete(CafeViewModel Entity)
        {
            var cafe = dbase.Cafe.Where
                (c => c.hostel_id == Entity.id && c.title == Entity.title).AsNoTracking().FirstOrDefault();
            dbase.Remove(cafe);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(CafeViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public CafeViewModel Get(string unique_value)
        {
            return (from h in dbase.Hostel
                   join c in dbase.Cafe
                   on h.id equals c.hostel_id
                   where c.title == unique_value
                   select new CafeViewModel
                   {
                       id = h.id,
                       hostel_name = h.title,
                       title = c.title
                   }).FirstOrDefault();
        }

        public CafeViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CafeViewModel> GetAll()
        {
            return (from h in dbase.Hostel
                    join c in dbase.Cafe
                    on h.id equals c.hostel_id
                    select new CafeViewModel
                    {
                        id = h.id,
                        hostel_name = h.title,
                        title = c.title
                    }).ToList();
        }

        public IEnumerable<CafeViewModel> GetAll(string unique_value)
        {
            return (from h in dbase.Hostel
                    join c in dbase.Cafe
                    on h.id equals c.hostel_id
                    where h.title == unique_value
                    select new CafeViewModel
                    {
                        id = h.id,
                        hostel_name = h.title,
                        title = c.title
                    }).ToList();
        }

        public IEnumerable<CafeViewModel> GetAll(string unique_value, string _hostel_name)
        {
            return (from h in dbase.Hostel
                    join c in dbase.Cafe
                    on h.id equals c.hostel_id
                    where c.title == unique_value &&
                    h.title == _hostel_name
                    select new CafeViewModel
                    {
                        id = h.id,
                        hostel_name = h.title,
                        title = c.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
