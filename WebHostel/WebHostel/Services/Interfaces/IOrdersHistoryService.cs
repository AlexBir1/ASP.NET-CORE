using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IOrdersHistoryService
    {
        public IBaseResponse<orders_historyViewModel>
            CreateOHistory(orders_historyViewModel orders_History);
        public IBaseResponse<orders_historyViewModel>
            DeleteOHistory(orders_historyViewModel orders_History);
        public IBaseResponse<orders_historyViewModel>
            EditOHistory(orders_historyViewModel orders_History);
        public IBaseResponse<IEnumerable<orders_historyViewModel>>
            GetOHistories();
    }
}
