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
    public class ManufactorerRepository : IBaseRepository<ManufactorerViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public ManufactorerRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(ManufactorerViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call AddManufactorer('{Entity.title}', '{Entity.country}', '{Entity.address}', '{Entity.phone}')");

            return true;
        }

        public bool Delete(ManufactorerViewModel Entity)
        {
            var manufactorer = dbase.Manufactorer
                .Where(m => m.phone == Entity.phone).FirstOrDefault();

            dbase.Remove(manufactorer);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(ManufactorerViewModel Entity, int id)
        {
            var manufactorer = dbase.Manufactorer
                .Where(m => m.id == id).FirstOrDefault();

            manufactorer = new Manufactorer
            {
                id = Entity.id,
                title = Entity.title,
                address = Entity.address,
                country = Entity.country,
                phone = Entity.phone
            };

            dbase.Update(manufactorer);
            dbase.SaveChanges();

            return true;
        }

        public ManufactorerViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public ManufactorerViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManufactorerViewModel> GetAll()
        {
            return (from m in dbase.Manufactorer
                    select new ManufactorerViewModel
                    {
                        id = m.id,
                        title = m.title,
                        address = m.address,
                        country = m.country,
                        phone = m.phone
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
