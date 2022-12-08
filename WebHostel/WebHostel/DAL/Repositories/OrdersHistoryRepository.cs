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
    public class OrdersHistoryRepository : IBaseRepository<orders_historyViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public OrdersHistoryRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(orders_historyViewModel Entity)
        {
            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.title)
                .FirstOrDefault();
            var oHistory = new orders_history
            {
                id = Entity.id,
                order_date = Entity.order_date,
                cost = Entity.cost,
                customer_phone = Entity.customer_phone,
                employee_phone = Entity.employee_phone,
                hostel_id = hostel.id,
                quantity = Entity.quantity,
                title = Entity.title
            };
            dbase.Add(oHistory);
            dbase.SaveChanges();
            return true;
        }

        public bool Delete(orders_historyViewModel Entity)
        {
            var oHistory = dbase.orders_history
                .Where(oH => oH.id == Entity.id).AsNoTracking()
                .FirstOrDefault();

            dbase.Remove(oHistory);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(orders_historyViewModel Entity, int id)
        {
            var hostel = dbase.Hostel
                .Where(h => h.title == Entity.hostel_name)
                .FirstOrDefault();

            var oHistory = dbase.orders_history.AsNoTracking()
                .FirstOrDefault(oH => oH.id == Entity.id);

            oHistory = new orders_history
            {
                id = Entity.id,
                order_date = Entity.order_date,
                cost = Entity.cost,
                customer_phone = Entity.customer_phone,
                employee_phone = Entity.employee_phone,
                hostel_id = hostel.id,
                quantity = Entity.quantity,
                title = Entity.title
            };
            dbase.Update(oHistory);
            dbase.SaveChanges();
            return true;
        }

        public orders_historyViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public orders_historyViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<orders_historyViewModel> GetAll()
        {
            return (from op in dbase.orders_history
                    join h in dbase.Hostel
                    on op.hostel_id equals h.id
                    select new orders_historyViewModel
                    {
                        id = op.id,
                        order_date = op.order_date,
                        cost = op.cost,
                        customer_phone = op.customer_phone,
                        employee_phone = op.employee_phone,
                        hostel_name = h.title,
                        quantity = op.quantity,
                        title = op.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
