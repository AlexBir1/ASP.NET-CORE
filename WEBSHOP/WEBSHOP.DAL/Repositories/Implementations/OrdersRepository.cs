using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.Enums;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Implementations
{
    public class OrdersRepository : IOrdersInterface
    {
        private readonly AppDBContext _db;

        public OrdersRepository(AppDBContext db)
        {
            _db = db;
        }

        public bool AddProductInOrder(int OrderId, int ProductId)
        {
            _db.OrderHasProduct.Add(new OrderHasProduct
            {
                Orders_Id = OrderId,
                Product_Id = ProductId
            });
            _db.SaveChanges();
            return true;
        }

        public bool Create(OrdersViewModel Entity)
        {
            var NewOrder = _db.Orders.Add(new Orders 
            {
                FullCost = Entity.ProductsIn.Sum(s=>s.Cost),
                DateCreate = DateTime.Now,
                User_Id = Entity.Owner.Id,
            });
            _db.SaveChanges();

            foreach (var item in Entity.ProductsIn) 
            {
                _db.OrderHasProduct.Add(new OrderHasProduct
                {
                    Orders_Id = NewOrder.Entity.Id,
                    Product_Id = item.Id
                });
                _db.SaveChanges();
            }
            return true;
        }

        public bool Delete(OrdersViewModel Entity)
        {
            _db.OrderHasProduct.RemoveRange(new OrderHasProduct 
            { 
                Orders_Id = Entity.Id 
            });
            _db.Orders.Remove(new Orders { Id = Entity.Id });
            _db.SaveChanges();
            return true;
        }

        public bool DeleteProductFromOrder(int OrderId, int ProductId)
        {
            var productList =_db.OrderHasProduct
                .Where(x => x.Orders_Id == OrderId && x.Product_Id == ProductId)
                .ToList();
            var product = productList.FirstOrDefault();
            _db.OrderHasProduct.Remove(product);
            _db.SaveChanges();
            return true;
        }

        public bool Edit(OrdersViewModel Entity)
        {
            var Order = new Orders
            {
                Id = Entity.Id,
                FullCost = Entity.FullCost,
                DateCreate = Entity.DateCreate,
                Status = (int)Entity.Status,
                User_Id = Entity.Owner.Id
            };
            _db.Update(Order);
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<OrdersViewModel>> GetAll()
        {
            return await (from o in _db.Orders
                          join u in _db.User
                          on o.User_Id equals u.Id
                                select new OrdersViewModel
                                {
                                    Id = o.Id,
                                    FullCost = o.FullCost,
                                    DateCreate = o.DateCreate,
                                    Status = (OrderStatus)o.Status,
                                    Owner = new UserViewModel
                                    {
                                        Id = u.Id,
                                        Fullname = u.Fullname,
                                        Phone = u.Phone
                                    }

                                }).ToListAsync();
        }

        public async Task<IEnumerable<OrdersViewModel>> GetAllByUserId(int Id)
        {

            var orders = await (from o in _db.Orders
                                join u in _db.User
                                on o.User_Id equals u.Id
                                where o.User_Id == Id 
                                select new OrdersViewModel
                                {
                                    Id = o.Id,
                                    FullCost = o.FullCost,
                                    DateCreate = o.DateCreate,
                                    Status = (OrderStatus)o.Status,
                                    Owner = new UserViewModel
                                    {
                                        Id = u.Id,
                                        Fullname = u.Fullname,
                                        Phone = u.Phone
                                    }
                                    
                                }).ToListAsync();


            return orders;
        }

        public async Task<OrdersViewModel> GetById(int Id)
        {
            return await (from o in _db.Orders
                          join u in _db.User
                          on o.User_Id equals u.Id
                          where o.Id == Id
                          select new OrdersViewModel
                          {
                              Id = o.Id,
                              FullCost = o.FullCost,
                              DateCreate = o.DateCreate,
                              Status = (OrderStatus)o.Status,
                              Owner = new UserViewModel
                              {
                                  Id = u.Id,
                                  Fullname = u.Fullname,
                                  Phone = u.Phone
                              }

                          }).FirstOrDefaultAsync();
        }
    }
}
