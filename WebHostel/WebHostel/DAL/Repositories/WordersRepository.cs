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
    public class WordersRepository : IBaseRepository<wordersViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public WordersRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(wordersViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call CreateWOrder(" +
               $"'{Entity.specie}', " +
               $"'{Entity.title}', " +
               $"'{Entity.order_date.ToString("yyyy-MM-dd")}', " +
               $"'{Entity.quantity}', " +
               $"'{Entity.cost}', " +
               $"'{Entity.wirehouse_name}', " +
               $"'{Entity.manufactorer_name}', " +
               $"'{Entity.employee_num}')");
            return true;
        }

        public bool Delete(wordersViewModel Entity)
        {
            var worder = dbase.worders.Where(w => w.id == Entity.id).FirstOrDefault();
            dbase.Remove(worder);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(wordersViewModel Entity, int id)
        {
            var wirehouse = dbase.Wirehouse.
                Where(w => w.title == Entity.wirehouse_name)
                .FirstOrDefault();

            var manufactorer = dbase.Manufactorer
                .Where(m => m.title == Entity.manufactorer_name)
                .FirstOrDefault();

            var worder = dbase.worders
                .Where(w => w.id == id).AsNoTracking()
                .FirstOrDefault();

            worder = new worders
            {
                order_date = Entity.order_date,
                cost = Entity.cost,
                employee_num = Entity.employee_num,
                id = Entity.id,
                manufactorer_id = manufactorer.id,
                quantity = Entity.quantity,
                specie = Entity.specie,
                status = (int)Entity.status,
                title = Entity.title,
                wirehouse_hostel_id = wirehouse.hostel_id
            };

            dbase.Update(worder);
            dbase.SaveChanges();

            return true;
        }

        public wordersViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public wordersViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<wordersViewModel> GetAll()
        {
            return (from wo in dbase.worders
                    join m in dbase.Manufactorer
                    on wo.manufactorer_id equals m.id
                    join w in dbase.Wirehouse
                    on wo.wirehouse_hostel_id equals w.hostel_id
                    select new wordersViewModel
                    {
                        order_date = wo.order_date,
                        cost = wo.cost,
                        employee_num = wo.employee_num,
                        id = wo.id,
                        manufactorer_name = m.title,
                        quantity = wo.quantity,
                        specie = wo.specie,
                        status = (WOStatuses)wo.status,
                        title = wo.title,
                        wirehouse_name = w.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
        public bool UpdateStatusWOrder(wordersViewModel worder)
        {
            dbase.Database.ExecuteSqlRaw
                ($"call UpdateStatusWOrder('{worder.title}','{worder.wirehouse_name}')");
            return true;
        }
    }
}
