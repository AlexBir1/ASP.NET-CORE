using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IWirehouseEmployeesService
    {
        public IBaseResponse<Wirehouse_employeesViewModel>
            CreateWEmployee(Wirehouse_employeesViewModel wirehouse_Employee);

        public IBaseResponse<Wirehouse_employeesViewModel>
            DeleteWEmployee(Wirehouse_employeesViewModel wirehouse_Employee);

        public IBaseResponse<Wirehouse_employeesViewModel>
            EditWEmployee(Wirehouse_employeesViewModel wirehouse_Employee);

        public IBaseResponse<IEnumerable<Wirehouse_employeesViewModel>>
            GetWEmployees();
    }
}
