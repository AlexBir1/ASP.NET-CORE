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
    public class UnitRepository : IUnitInterface
    {
        private readonly AppDBContext _db;

        public UnitRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool Create(UnitViewModel Entity)
        {
            _db.Unit.Add(new Unit 
            {
                Title = Entity.Title, 
                Address = Entity.Address 
            });
            _db.SaveChanges();
            return true;
        }

        public bool Delete(UnitViewModel Entity)
        {
            _db.Unit.Remove(new Unit
            {
                Id = Entity.Id,
                Title = Entity.Title,
                Address = Entity.Address
            });
            _db.SaveChanges();
            return true;
        }

        public bool Edit(UnitViewModel Entity)
        {
            _db.Unit.Update(new Unit
            {
                Id = Entity.Id,
                Title = Entity.Title,
                Address = Entity.Address
            });
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<UnitViewModel>> GetAll()
        {
            return await (from u in _db.Unit
                          select new UnitViewModel
                          {
                              Id = u.Id,
                              Title = u.Title,
                              Address = u.Address
                          }).ToListAsync();
        }

        public async Task<UnitViewModel> GetById(int Id)
        {
            return await (from u in _db.Unit
                          where u.Id == Id
                          select new UnitViewModel
                          {
                              Id = u.Id,
                              Title = u.Title,
                              Address = u.Address
                          }).FirstOrDefaultAsync();
        }
    }
}
