using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IOrdersService
    {
        public IBaseResponse<OrdersViewModel> CreateOrders(OrdersViewModel _Orders);
        public IBaseResponse<OrdersViewModel> EditOrders(OrdersViewModel _Orders);
        public IBaseResponse<OrdersViewModel> DeleteOrders(OrdersViewModel _Orders);
        public IBaseResponse<OrdersViewModel> GetOrder(string Orders_name);
        public IBaseResponse<IEnumerable<OrdersViewModel>> GetOrders();
    }
}
