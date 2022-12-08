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
    public class Chosen_servicesRepository : IBaseRepository<ChosenServicesViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public Chosen_servicesRepository(ApplicationDBContext dbc)
        {
            dbase = dbc;
        }

        public bool Create(ChosenServicesViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call SelectService('{Entity.title}', '{Entity.customer_num}', '{Entity.hostel_name}')");
            return true;
        }

        public bool Delete(ChosenServicesViewModel Entity)
        {
            var cservice = dbase.chosen_services.Where(cs =>
            cs.id == Entity.id).AsNoTracking().FirstOrDefault();

            dbase.Remove(cservice);
            dbase.SaveChanges();

            return true;
        }

        public bool Edit(ChosenServicesViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public ChosenServicesViewModel Get(string unique_value)
        {
            return (from cs in dbase.chosen_services
                    join c in dbase.Customers
                    on cs.customers_id equals c.id
                    join e in dbase.Employees
                    on cs.employees_id equals e.id
                    where c.phone == unique_value
                    select new ChosenServicesViewModel
                    {
                        id = cs.id,
                        title = cs.chd_service,
                        cost = cs.cost,
                        status = cs.status,
                        hostel_name = cs.hostel_name,
                        customer_num = c.phone,
                        employee_num = e.phone
                    }).FirstOrDefault();
        }

        public ChosenServicesViewModel Get(string unique_value, string _hostel_name)
        {
            return (from cs in dbase.chosen_services
                    join c in dbase.Customers
                    on cs.customers_id equals c.id
                    join e in dbase.Employees
                    on cs.employees_id equals e.id
                    where c.phone == unique_value &&
                    cs.hostel_name == _hostel_name
                    select new ChosenServicesViewModel
                    {
                        id = cs.id,
                        title = cs.chd_service,
                        cost = cs.cost,
                        status = cs.status,
                        hostel_name = cs.hostel_name,
                        customer_num = c.phone,
                        employee_num = e.phone
                    }).FirstOrDefault();
        }

        public IEnumerable<ChosenServicesViewModel> GetAll()
        {
            return (from cs in dbase.chosen_services
                    join c in dbase.Customers
                    on cs.customers_id equals c.id
                    join e in dbase.Employees
                    on cs.employees_id equals e.id
                    select new ChosenServicesViewModel
                    {
                        id = cs.id,
                        title = cs.chd_service,
                        cost = cs.cost,
                        status = cs.status,
                        hostel_name = cs.hostel_name,
                        customer_num = c.phone,
                        employee_num = e.phone
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
        public bool UpdateServiceStatus(ChosenServicesViewModel Entity)
        {
            dbase
               .Database
               .ExecuteSqlRaw
               ($"call UpdateServiceStatus('{Entity.id}')");
            return true;
        }
    }
}
