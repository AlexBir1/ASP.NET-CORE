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
    public class OrdersService : IOrdersService
    {
        private readonly OrdersRepository OrdersRepository;

        public OrdersService(OrdersRepository _OrdersRepository)
        {
            OrdersRepository = _OrdersRepository;
        }

        public IBaseResponse<OrdersViewModel> CreateOrders(OrdersViewModel _Orders)
        {
            var BaseRes = new DBResponse<OrdersViewModel>();
            try
            {
                OrdersRepository.Create(_Orders);
                var new_Orders = OrdersRepository.GetAll()
                    .FirstOrDefault(o=>o.title == _Orders.title);
                if (new_Orders != null)
                {
                    BaseRes.Data = new_Orders;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<OrdersViewModel>
                {
                    Description = $"[CreateOrders] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<OrdersViewModel> DeleteOrders(OrdersViewModel _Orders)
        {
            var BaseRes = new DBResponse<OrdersViewModel>();
            try
            {
                OrdersRepository.Delete(_Orders);
                var new_Orders = OrdersRepository.GetAll()
                    .FirstOrDefault(o => o.id == _Orders.id);
                if (new_Orders == null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<OrdersViewModel>
                {
                    Description = $"[DeleteOrders] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<OrdersViewModel> EditOrders(OrdersViewModel _Orders)
        {
            var BaseRes = new DBResponse<OrdersViewModel>();
            try
            {
                OrdersRepository.Edit(_Orders, _Orders.id);
                var new_hostel = OrdersRepository.GetAll()
                    .FirstOrDefault(o => o.id == _Orders.id);
                if (new_hostel == _Orders)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<OrdersViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<OrdersViewModel> GetOrder(string Orders_name)
        {
            var BaseRes = new DBResponse<OrdersViewModel>();
            try
            {
                var Orders = OrdersRepository.Get(Orders_name);
                if (Orders != null)
                {
                    BaseRes.Data = Orders;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<OrdersViewModel>
                {
                    Description = $"[GetOrders] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<OrdersViewModel>> GetOrders()
        {
            var BaseRes = new DBResponse<IEnumerable<OrdersViewModel>>();
            try
            {
                var Orderss = OrdersRepository.GetAll();
                if (Orderss.Count() != 0)
                {
                    BaseRes.Data = Orderss;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<OrdersViewModel>>
                {
                    Description = $"[GetOrderss] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<OrdersViewModel> UpdateOrderStatus(OrdersViewModel order)
        {
            try
            {
                if (OrdersRepository.UpdateOrderStatus(order))
                {
                    return new DBResponse<OrdersViewModel>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<OrdersViewModel>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Ошибка!"
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<OrdersViewModel>
                {
                    Description = $"[UpdateOrderStatus]: {ex.Message}"
                };
            }
        }
        public IBaseResponse<OrdersViewModel> UpdateOrderEStatus(OrdersViewModel order)
        {
            try
            {
                if (OrdersRepository.UpdateOrderEStatus(order))
                {
                    return new DBResponse<OrdersViewModel>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<OrdersViewModel>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Ошибка!"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<OrdersViewModel>
                {
                    Description = $"[UpdateOrderStatus]: {ex.Message}"
                };
            }
        }
    }
}
