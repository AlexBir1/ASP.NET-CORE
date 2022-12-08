using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Domain.Enum;
using WebHostel.Models;

namespace WebHostel.DAL.Repositories
{
    public class ProductsRepository : IBaseRepository<ProductsViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public ProductsRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(ProductsViewModel Entity)
        {
            var whouse = dbase.Wirehouse
                .FirstOrDefault(w => w.title == Entity.wirehouse_name);
            var prod = new Products
            {
                id = Entity.id,
                specie = Entity.specie,
                title = Entity.title,
                quantity = Entity.quantity,
                cost = Entity.cost,
                wirehouse_hostel_id = whouse.hostel_id
            };
            dbase.Products.Add(prod);
            dbase.SaveChanges();
            return true;
        }

        public bool Delete(ProductsViewModel Entity)
        {
            var _prod = dbase.Products
                .Where(p => p.id == Entity.id)
                .FirstOrDefault();

            var whouse = dbase.Wirehouse
                .Where(w => w.hostel_id == _prod.wirehouse_hostel_id)
                .FirstOrDefault();

            var prod = new Products
            {
                id = _prod.id,
                specie = _prod.specie,
                title = _prod.title,
                quantity = _prod.quantity,
                cost = _prod.cost,
                wirehouse_hostel_id = whouse.hostel_id
            };
            dbase.Products.Remove(prod);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(ProductsViewModel Entity, int id)
        {
            var whouse = dbase.Wirehouse
               .FirstOrDefault(w => w.title == Entity.wirehouse_name);
            var prod = dbase.Products.FirstOrDefault(p => p.id == id);
            prod = new Products
            {
                id = Entity.id,
                specie = Entity.specie,
                title = Entity.title,
                quantity = Entity.quantity,
                cost = Entity.cost,
                wirehouse_hostel_id = whouse.hostel_id
            };
            dbase.Update(prod);
            dbase.SaveChanges();
            return true;
        }

        public ProductsViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public ProductsViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsViewModel> GetAll()
        {
            return (from p in dbase.Products
                    join w in dbase.Wirehouse
                    on p.wirehouse_hostel_id equals w.hostel_id
                    select new ProductsViewModel
                    {
                        id = p.id,
                        specie = p.specie,
                        title = p.title,
                        quantity = p.quantity,
                        cost = p.cost,
                        wirehouse_name = w.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
