using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IEmployeeSpendsService
    {
        public IBaseResponse<Employee_spendsViewModel> 
            CreateEmployeeSpends(Employee_spendsViewModel employee_Spends);
        public IBaseResponse<Employee_spendsViewModel>
            DeleteEmployeeSpends(Employee_spendsViewModel employee_Spends);
        public IBaseResponse<Employee_spendsViewModel>
            EditEmployeeSpends(Employee_spendsViewModel employee_Spends);
        public IBaseResponse<IEnumerable<Employee_spendsViewModel>>
            GetEmployeeSpends();
    }
}
