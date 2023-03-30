using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Implementations
{
    public class ManufactorerRepository : IManufactorerInterface
    {
        private readonly AppDBContext _db;

        public ManufactorerRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool Create(ManufactorerViewModel Entity)
        {
            _db.Manufactorer.Add(new Manufactorer
            {
                Title = Entity.Title,
                Phone = Entity.Phone,
                Email = Entity.Email,
                Address = Entity.Address,
                Country = Entity.Country
            });
            _db.SaveChanges();
            return true;
        }

        public bool Delete(ManufactorerViewModel Entity)
        {
            _db.Manufactorer.Remove(new Manufactorer
            {
                Id = Entity.Id,
                Title = Entity.Title,
                Phone = Entity.Phone,
                Email = Entity.Email,
                Address = Entity.Address,
                Country = Entity.Country
            });
            _db.SaveChanges();
            return true;
        }

        public bool Edit(ManufactorerViewModel Entity)
        {
            _db.Manufactorer.Update(new Manufactorer
            {
                Id = Entity.Id,
                Title = Entity.Title,
                Phone = Entity.Phone,
                Email = Entity.Email,
                Address = Entity.Address,
                Country = Entity.Country
            });
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<ManufactorerViewModel>> GetAll()
        {
            return await (from m in _db.Manufactorer
                          select new ManufactorerViewModel
                          {
                              Id = m.Id,
                              Title = m.Title,
                              Phone = m.Phone,
                              Country = m.Country,
                              Email = m.Email,
                              Address = m.Address
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<ManufactorerViewModel> GetById(int Id)
        {
            return await (from m in _db.Manufactorer
                          where m.Id == Id
                          select new ManufactorerViewModel
                          {
                              Id = m.Id,
                              Title = m.Title,
                              Phone = m.Phone,
                              Country = m.Country,
                              Email = m.Email,
                              Address = m.Address
                          }).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
