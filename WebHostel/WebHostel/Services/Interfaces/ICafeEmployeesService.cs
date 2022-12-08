using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface ICafeEmployeesService
    {
        public IBaseResponse<Cafe_employeesViewModel> 
            CreateCafeEmployee(Cafe_employeesViewModel cafe_Employees);

        public IBaseResponse<Cafe_employeesViewModel> 
            EditCafeEmployee(Cafe_employeesViewModel cafe_Employees);

        public IBaseResponse<Cafe_employeesViewModel> 
            DeleteCafeEmployee(Cafe_employeesViewModel cafe_Employees);

        public IBaseResponse<IEnumerable<Cafe_employeesViewModel>> 
            GetCafeEmployees();
    }
}
