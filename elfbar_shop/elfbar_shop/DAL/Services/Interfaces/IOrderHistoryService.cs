using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface IOrderHistoryService
    {
        public IBaseResponse<OrderHistoryViewModel> 
            CreateOHistory(OrderHistoryViewModel _orderHistory);
        public IBaseResponse<OrderHistoryViewModel>
            DeleteOHistory(OrderHistoryViewModel _orderHistory);
        public IBaseResponse<OrderHistoryViewModel>
            EditOHistory(OrderHistoryViewModel _orderHistory);
        public IBaseResponse<OrderHistoryPageViewModel> GetOHistories();
    }
}
