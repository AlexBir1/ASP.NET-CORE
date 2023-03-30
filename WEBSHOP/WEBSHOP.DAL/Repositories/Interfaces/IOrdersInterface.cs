using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Interfaces
{
    public interface IOrdersInterface : IBaseInterface<OrdersViewModel>
    {
        public Task<IEnumerable<OrdersViewModel>> GetAllByUserId(int Id);
        public bool DeleteProductFromOrder(int OrderId, int ProductId);
        public bool AddProductInOrder(int OrderId, int ProductId);
    }
}
