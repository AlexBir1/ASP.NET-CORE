using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Models;
using Microsoft.EntityFrameworkCore;

namespace WebHostel.DAL.Repositories
{
    public class OrdersRepository : IBaseRepository<OrdersViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public OrdersRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(OrdersViewModel Entity)
        {
            dbase
            .Database
            .ExecuteSqlRaw
            ($"call CreateOrder(" +
            $"'{Entity.customer_num}', " +
            $"'{Entity.title}', " +
            $"'{Entity.quantity}')");
            return true;
        }

        public bool Delete(OrdersViewModel Entity)
        {
            var order = dbase.Orders
                .Where(o => o.id == Entity.id)
                .FirstOrDefault();
            dbase.Remove(order);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(OrdersViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public OrdersViewModel Get(string unique_value)
        {
            return (from o in dbase.Orders
                    join e in dbase.Cafe_employees
                    on o.cafe_employees_id equals e.id
                    where o.customer_num == unique_value
                    select new OrdersViewModel
                    {
                        id = o.id,
                        title = o.title,
                        quantity = o.quantity,
                        cost = o.cost,
                        status = o.status,
                        customer_num = o.customer_num,
                        cafe_employees_num = e.phone
                    }).FirstOrDefault();
        }

        public OrdersViewModel Get(string unique_value, string _hostel_name)
        {
            return (from o in dbase.Orders
                    join e in dbase.Employees
                    on o.cafe_employees_id equals e.id
                    where o.customer_num == unique_value
                    select new OrdersViewModel
                    {
                        id = o.id,
                        title = o.title,
                        quantity = o.quantity,
                        cost = o.cost,
                        status = o.status,
                        customer_num = o.customer_num,
                        cafe_employees_num = e.phone
                    }).FirstOrDefault();
        }

        public IEnumerable<OrdersViewModel> GetAll()
        {
            return (from o in dbase.Orders
                    join e in dbase.Employees
                    on o.cafe_employees_id equals e.id
                    select new OrdersViewModel 
                    {
                        id = o.id,
                        title = o.title,
                        quantity = o.quantity,
                        cost = o.cost,
                        status = o.status,
                        customer_num = o.customer_num,
                        cafe_employees_num = e.phone
                    }).ToList();
        }

        public IEnumerable<OrdersViewModel> GetAll(string _phone)
        {
            return (from o in dbase.Orders
                    join e in dbase.Employees
                    on o.cafe_employees_id equals e.id
                    where o.customer_num == _phone
                    select new OrdersViewModel
                    {
                        id = o.id,
                        title = o.title,
                        quantity = o.quantity,
                        cost = o.cost,
                        status = o.status,
                        customer_num = o.customer_num,
                        cafe_employees_num = e.phone
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
        public bool UpdateOrderStatus(OrdersViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call UpdateOrderStatus('{Entity.id}')");
            return true;
        }
        public bool UpdateOrderEStatus(OrdersViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call UpdateOrderEStatus('{Entity.id}')");
            return true;
        }
    }
}
