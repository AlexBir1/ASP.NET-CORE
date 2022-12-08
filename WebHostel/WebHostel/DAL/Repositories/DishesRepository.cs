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
    public class DishesRepository : IBaseRepository<DishesViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public DishesRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(DishesViewModel Entity)
        {
            dbase
            .Database
            .ExecuteSqlRaw
            ($"call CreateDish('{Entity.title}', '{Entity.ingreds}', '{Entity.cafe_name}')");
            return true;
        }

        public bool Delete(DishesViewModel Entity)
        {
            var _dish = dbase.Dishes
                .Where(d => d.id == Entity.id)
                .FirstOrDefault();
            dbase.Remove(_dish);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(DishesViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public DishesViewModel Get(string unique_value)
        {
            return (from d in dbase.Dishes
                    join c in dbase.Cafe
                    on d.cafe_hostel_id equals c.hostel_id
                    where d.title == unique_value
                    select new DishesViewModel
                    {
                        id = d.id,
                        cafe_name = c.title,
                        title = d.title,
                        cost = d.cost,
                        ingreds = d.ingreds
                    }).FirstOrDefault();
        }

        public DishesViewModel Get(string unique_value, string _hostel_name)
        {
            return (from d in dbase.Dishes
                    join c in dbase.Cafe
                    on d.cafe_hostel_id equals c.hostel_id
                    join h in dbase.Hostel on c.hostel_id equals h.id
                    where c.title == _hostel_name && d.title == unique_value
                    select new DishesViewModel
                    {
                        id = d.id,
                        cafe_name = c.title,
                        title = d.title,
                        cost = d.cost,
                        ingreds = d.ingreds
                    }).FirstOrDefault();
        }

        public IEnumerable<DishesViewModel> GetAll()
        {
            return (from d in dbase.Dishes
                    join c in dbase.Cafe
                    on d.cafe_hostel_id equals c.hostel_id
                    select new DishesViewModel
                    {
                        id = d.id,
                        cafe_name = c.title,
                        title = d.title,
                        cost = d.cost,
                        ingreds = d.ingreds
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
