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
    public class CarsRepository : IBaseRepository<CarsViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public CarsRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(CarsViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call CreateCar('" +
               $"{Entity.specie}', " +
               $"'{Entity.firm}', " +
               $"'{Entity.num}, " +
               $"'{Entity.FuelType}, " +
               $"'{Entity.FuelPer100}, " +
               $"'{Entity.hostel_name}')");
            return true;
        }

        public bool Delete(CarsViewModel Entity)
        {
            var car = dbase.Cars.Where(c => c.num == Entity.num).FirstOrDefault();

            dbase.Remove(car);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(CarsViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarsViewModel> GetAll()
        {
            return (from h in dbase.Hostel
                    join c in dbase.Cars
                    on h.id equals c.hostel_id
                    select new CarsViewModel
                    {
                        id = c.id,
                        specie = c.specie,
                        firm = c.firm,
                        num = c.num,
                        FuelType = c.FuelType,
                        FuelPer100 = c.FuelPer100,
                        hostel_name = h.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }

        public CarsViewModel Get(string unique_value)
        {
            return (from h in dbase.Hostel
                    join c in dbase.Cars
                    on h.id equals c.hostel_id
                    where c.num == unique_value
                    select new CarsViewModel
                    {
                        id = c.id,
                        specie = c.specie,
                        firm = c.firm,
                        num = c.num,
                        FuelType = c.FuelType,
                        FuelPer100 = c.FuelPer100,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public CarsViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }
    }
}
