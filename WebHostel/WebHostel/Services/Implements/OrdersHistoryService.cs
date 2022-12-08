using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Implements
{
    public class OrdersHistoryService : IOrdersHistoryService
    {
        private readonly OrdersHistoryRepository ordersHistory;

        public OrdersHistoryService(OrdersHistoryRepository _OrdersHistory)
        {
            ordersHistory = _OrdersHistory;
        }

        public IBaseResponse<orders_historyViewModel> 
            CreateOHistory(orders_historyViewModel orders_History)
        {
            try
            {
                ordersHistory.Create(orders_History);
                if (ordersHistory.GetAll().FirstOrDefault(oh=>oh.title == orders_History.title
                && oh.order_date == orders_History.order_date
                && oh.hostel_name == orders_History.hostel_name
                && oh.customer_phone == orders_History.customer_phone
                && oh.employee_phone == orders_History.employee_phone) != null)
                {
                    return new DBResponse<orders_historyViewModel>
                    {
                        Description = "inserted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<orders_historyViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<orders_historyViewModel>
                {
                    Description = $"[CreateOHistory] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<orders_historyViewModel> 
            DeleteOHistory(orders_historyViewModel orders_History)
        {
            try
            {
                ordersHistory.Delete(orders_History);
                if (ordersHistory.GetAll().FirstOrDefault(oh => oh.id == orders_History.id) == null)
                {
                    return new DBResponse<orders_historyViewModel>
                    {
                        Description = "deleted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<orders_historyViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<orders_historyViewModel>
                {
                    Description = $"[DeleteOHistory] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<orders_historyViewModel> 
            EditOHistory(orders_historyViewModel orders_History)
        {
            try
            {
                ordersHistory.Edit(orders_History, orders_History.id);
                var d = ordersHistory.GetAll().FirstOrDefault(oh => oh.id == orders_History.id);
                if (d.id == orders_History.id)
                {
                    return new DBResponse<orders_historyViewModel>
                    {
                        Description = "edited",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<orders_historyViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<orders_historyViewModel>
                {
                    Description = $"[EditOHistory] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<orders_historyViewModel>> GetOHistories()
        {
            try
            {
                var orders_Histories = ordersHistory.GetAll();
                if (orders_Histories.Count() != 0)
                {
                    return new DBResponse<IEnumerable<orders_historyViewModel>>
                    {
                        Data = orders_Histories,
                        Description = "found",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<orders_historyViewModel>>
                {
                    Description = "not found any",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<orders_historyViewModel>>
                {
                    Description = $"[GetOHistories] : {ex.Message}"
                };
            }
        }
    }
}
