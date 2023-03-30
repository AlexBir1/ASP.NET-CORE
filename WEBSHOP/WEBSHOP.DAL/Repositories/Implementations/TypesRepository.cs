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
    public class TypesRepository : ITypesInterface
    {
        private readonly AppDBContext _db;

        public TypesRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool Create(TypesViewModel Entity)
        {
            _db.Types.Add(new Types { 
                Title = Entity.Title,
                PicturePath = Entity.PicturePath
            });
            _db.SaveChanges();
            return true;
        }

        public bool Delete(TypesViewModel Entity)
        {
            if (_db.Types.Where(t => t.Id == Entity.Id).AsNoTracking().FirstOrDefault() != null)
            {
                _db.Types.Remove(new Types
                {
                    Id = Entity.Id,
                    Title = Entity.Title,
                    PicturePath = Entity.PicturePath
                });
                _db.SaveChanges();
            }
            return true;
        }

        public bool Edit(TypesViewModel Entity)
        {
            _db.Types.Update(new Types 
            { 
                Id = Entity.Id, 
                Title = Entity.Title,
                PicturePath = Entity.PicturePath
            });
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<TypesViewModel>> GetAll()
        {
            return await (from t in _db.Types
                          select new TypesViewModel 
                          { 
                              Id = t.Id, 
                              Title = t.Title,
                              PicturePath = t.PicturePath
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<TypesViewModel> GetById(int Id)
        {
            return await (from t in _db.Types
                          where t.Id == Id
                          select new TypesViewModel
                          {
                              Id = t.Id,
                              Title = t.Title,
                              PicturePath = t.PicturePath
                          }).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
