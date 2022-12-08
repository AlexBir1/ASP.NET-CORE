using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Interfaces
{
    public interface IEmployeesService
    {
        public IBaseResponse<EmployeesViewModel> 
            CreateEmployee(EmployeesViewModel employee);
        public IBaseResponse<EmployeesViewModel>
            DeleteEmployee(EmployeesViewModel employee);
        public IBaseResponse<EmployeesViewModel>
            EditEmployee(EmployeesViewModel employee);
        public IBaseResponse<IEnumerable<EmployeesViewModel>>
            GetEmployees();
    }
}
