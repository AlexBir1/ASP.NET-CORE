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
    public class ProductRepository : IProductInterface
    {
        private readonly AppDBContext _db;

        public ProductRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool Create(ProductViewModel Entity)
        {
            _db.Product.Add(new Product
            {
                Title = Entity.Title,
                Cost = Entity.Cost,
                Quantity = Entity.Quantity,
                PicturePath = Entity.PicturePath,
                Type_Id = _db.Types.Where(t => t.Title == Entity.ProductType).AsNoTracking().Select(t => t.Id).FirstOrDefault(),
                Manufactorer_Id = _db.Manufactorer.Where(u => u.Title == Entity.ProductManufactorer).AsNoTracking().Select(t => t.Id).FirstOrDefault(),
                Unit_Id = _db.Unit.Where(u => u.Title == Entity.ProductUnit).AsNoTracking().Select(t => t.Id).FirstOrDefault()
            });
            _db.SaveChanges();
            return true;
        }

        public bool Delete(ProductViewModel Entity)
        {
            _db.Product.Remove(new Product {Id = Entity.Id });
            _db.SaveChanges();
            return true;
        }

        public bool Edit(ProductViewModel Entity)
        {
            _db.Product.Update(new Product
            {
                Id = Entity.Id,
                Title = Entity.Title,
                Cost = Entity.Cost,
                Quantity = Entity.Quantity,
                PicturePath = Entity.PicturePath,
                Type_Id = _db.Types.Where(t => t.Title == Entity.Title).AsNoTracking().Select(t => t.Id).FirstOrDefault(),
                Manufactorer_Id = _db.Manufactorer.Where(u => u.Title == Entity.ProductManufactorer).AsNoTracking().Select(t => t.Id).FirstOrDefault(),
                Unit_Id = _db.Unit.Where(u => u.Title == Entity.ProductUnit).AsNoTracking().Select(t => t.Id).FirstOrDefault()
            });
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            return await (from p in _db.Product
                          join t in _db.Types on p.Type_Id equals t.Id
                          join m in _db.Manufactorer on p.Manufactorer_Id equals m.Id
                          join u in _db.Unit on p.Unit_Id equals u.Id
                          select new ProductViewModel
                          {
                              Id = p.Id,
                              Cost = p.Cost,
                              PicturePath = p.PicturePath,
                              ProductType = t.Title,
                              Title = p.Title,
                              Quantity = p.Quantity,
                              ProductUnit = u.Title,
                              ProductManufactorer = m.Title
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<ProductViewModel> GetById(int Id)
        {
            return await (from p in _db.Product
                          join t in _db.Types on p.Type_Id equals t.Id
                          join m in _db.Manufactorer on p.Manufactorer_Id equals m.Id
                          join u in _db.Unit on p.Unit_Id equals u.Id
                          where p.Id == Id
                          select new ProductViewModel
                          {
                              Id = p.Id,
                              Cost = p.Cost,
                              PicturePath = p.PicturePath,
                              ProductType = t.Title,
                              Title = p.Title,
                              Quantity = p.Quantity,
                              ProductUnit = u.Title,
                              ProductManufactorer = m.Title
                              
                          }).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllByType(int type_id)
        {
            return await (from p in _db.Product
                          join t in _db.Types on p.Type_Id equals t.Id
                          join m in _db.Manufactorer on p.Manufactorer_Id equals m.Id
                          join u in _db.Unit on p.Unit_Id equals u.Id
                          where t.Id == type_id
                          select new ProductViewModel
                          {
                              Id = p.Id,
                              Cost = p.Cost,
                              PicturePath = p.PicturePath,
                              ProductType = t.Title,
                              Title = p.Title,
                              Quantity = p.Quantity,
                              ProductUnit = u.Title,
                              ProductManufactorer = m.Title
                              
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllByOrderId(int OrderId)
        {
            return await (from p in _db.Product
                          join t in _db.Types on p.Type_Id equals t.Id
                          join m in _db.Manufactorer on p.Manufactorer_Id equals m.Id
                          join u in _db.Unit on p.Unit_Id equals u.Id
                          join ohp in _db.OrderHasProduct on p.Id equals ohp.Product_Id
                          where ohp.Orders_Id == OrderId
                          select new ProductViewModel
                          {
                              Id = p.Id,
                              Cost = p.Cost,
                              PicturePath = p.PicturePath,
                              ProductType = t.Title,
                              Title = p.Title,
                              Quantity = p.Quantity,
                              ProductUnit = u.Title,
                              ProductManufactorer = m.Title
                          }).ToListAsync();
        }

        public void GetDataForCU(ref List<TypesViewModel> _locallyCreatedTypeList, ref List<UnitViewModel> __locallyCreatedUnitList, ref List<ManufactorerViewModel> _locallyCreatedMnfList)
        {
            __locallyCreatedUnitList = (from u in _db.Unit
                                        select new UnitViewModel
                                        {
                                            Id = u.Id,
                                            Title = u.Title,
                                        }).ToList();

            _locallyCreatedTypeList = (from t in _db.Types
                                       select new TypesViewModel
                                       {
                                           Id = t.Id,
                                           Title = t.Title,
                                       }).ToList();

            _locallyCreatedMnfList = (from mnf in _db.Manufactorer
                                      select new ManufactorerViewModel
                                      {
                                          Id = mnf.Id,
                                          Title = mnf.Title
                                      }).ToList();
        }


    }
}
