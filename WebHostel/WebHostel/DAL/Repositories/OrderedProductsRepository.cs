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
    public class OrderedProductsRepository : IBaseRepository<ordered_productsViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public OrderedProductsRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(ordered_productsViewModel Entity)
        {
            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.title)
                .FirstOrDefault();
            var oProducts = new ordered_products
            {
                id = Entity.id,
                specie = Entity.specie,
                title = Entity.title,
                cost = Entity.cost,
                hostel_id = hostel.id,
                order_date = Entity.order_date,
                quantity = Entity.quantity
            };
            dbase.Add(oProducts);
            dbase.SaveChanges();
            return true;
        }

        public bool Delete(ordered_productsViewModel Entity)
        {
            var oProducts = dbase.ordered_products
                .Where(op => op.id == Entity.id)
                .FirstOrDefault();

            dbase.Remove(oProducts);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(ordered_productsViewModel Entity, int id)
        {
            var oProducts = dbase.ordered_products
                .Where(op => op.id == id)
                .FirstOrDefault();

            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.hostel_name)
                .FirstOrDefault();

            oProducts = new ordered_products
            {
                id = Entity.id,
                specie = Entity.specie,
                title = Entity.title,
                cost = Entity.cost,
                hostel_id = hostel.id,
                order_date = Entity.order_date,
                quantity = Entity.quantity
            };
            dbase.Update(oProducts);
            dbase.SaveChanges();
            return true;
        }

        public ordered_productsViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public ordered_productsViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ordered_productsViewModel> GetAll()
        {
            return (from op in dbase.ordered_products
                    join h in dbase.Hostel
                    on op.hostel_id equals h.id
                    select new ordered_productsViewModel
                    {
                        id = op.id,
                        order_date = op.order_date,
                        cost = op.cost,
                        hostel_name = h.title,
                        quantity = op.quantity,
                        specie = op.specie,
                        title = op.title
                    }).ToList();

        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
