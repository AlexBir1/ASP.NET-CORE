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
    public class BinRepository : IBinInterface
    {
        private readonly AppDBContext _db;

        public BinRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool Create(BinViewModel Entity)
        {
                _db.Bin.Add(new Bin
                {
                    Product_Id = Entity.Product.Id,
                    User_Id = Entity.Owner.Id,
                });
            _db.SaveChanges();
                return true;
        }

        public bool Delete(BinViewModel Entity)
        {
            _db.Bin.Remove(new Bin
            {
                Id = Entity.Id
            });
            _db.SaveChanges();
            return true;
        }

        public bool DeleteAllByUserId(int UserId)
        {
            var Cart = _db.Bin.Where(x => x.User_Id == UserId).ToList();
            _db.Bin.RemoveRange(Cart);
            _db.SaveChanges();
            return true;
        }

        public bool Edit(BinViewModel Entity)
        {
            _db.Bin.Update(new Bin
            {
                Product_Id = Entity.Product.Id,
                User_Id = Entity.Owner.Id,
            });
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<BinViewModel>> GetAll()
        {
            return await (from b in _db.Bin
                    join p in _db.Product
                    on b.Product_Id equals p.Id
                    join c in _db.User
                    on b.User_Id equals c.Id
                    select new BinViewModel
                    {
                        Id = b.Id,
                        Owner = new UserViewModel
                        {
                            Id = c.Id,
                            Fullname = c.Fullname,
                            Phone = c.Phone
                        },
                        Product = new ProductViewModel
                        {
                            Id = p.Id,
                            Title = p.Title,
                            Cost = p.Cost
                        }
                    }).ToListAsync();
        }

        public async Task<BinViewModel> GetById(int Id)
        {
            return await (from b in _db.Bin
                          join p in _db.Product
                          on b.Product_Id equals p.Id
                          join c in _db.User
                          on b.User_Id equals c.Id
                          select new BinViewModel
                          {
                              Id = b.Id,
                              Owner = new UserViewModel
                              {
                                  Id = c.Id,
                                  Fullname = c.Fullname,
                                  Phone = c.Phone
                              },
                              Product = new ProductViewModel
                              {
                                  Id = p.Id,
                                  Title = p.Title,
                                  Cost = p.Cost
                              }
                          }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BinViewModel>> GetByUserId(int Id)
        {
            return await (from b in _db.Bin
                          join p in _db.Product
                          on b.Product_Id equals p.Id
                          join c in _db.User
                          on b.User_Id equals c.Id
                          where b.User_Id == Id
                          select new BinViewModel
                          {
                              Id = b.Id,
                              Owner = new UserViewModel
                              {
                                  Id = c.Id,
                                  Fullname = c.Fullname,
                                  Phone = c.Phone
                              },
                              Product = new ProductViewModel
                              {
                                  Id = p.Id,
                                  Title = p.Title,
                                  Cost = p.Cost
                              }
                          }).ToListAsync();
        }
    }
}
