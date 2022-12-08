using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface ICustomersService
    {
        public IBaseResponse<CustomersViewModel> CreateCustomers(CustomersViewModel _Customers);
        public IBaseResponse<CustomersViewModel> EditCustomers(CustomersViewModel _Customers);
        public IBaseResponse<CustomersViewModel> DeleteCustomers(CustomersViewModel _Customers);
        public IBaseResponse<CustomersViewModel> GetCustomers(string Customers_name);
        public IBaseResponse<IEnumerable<CustomersViewModel>> GetCustomerss();
    }
}
