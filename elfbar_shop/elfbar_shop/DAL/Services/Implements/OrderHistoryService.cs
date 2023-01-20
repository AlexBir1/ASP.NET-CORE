using elfbar_shop.Domain.Entities;
using elfbar_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using elfbar_shop.DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using elfbar_shop.Domain.Response;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace elfbar_shop.DAL.Services.Implements
{
    public class OrderHistoryService : IOrderHistoryService
    {
        private readonly AppDBContext dbase;

        public OrderHistoryService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<OrderHistoryViewModel> CreateOHistory(OrderHistoryViewModel _orderHistory)
        {
            try
            {
                var OrderHistory = new Order_history
                {
                    id = _orderHistory.id,
                    product_type = _orderHistory.product_type,
                    product_name = _orderHistory.product_name,
                    order_date = _orderHistory.order_date,
                    cost = _orderHistory.cost,
                    seller_alias = _orderHistory.seller_alias
                };
                dbase.Order_history.Add(OrderHistory);
                dbase.SaveChanges();
                if (dbase.Order_history
                    .Where(oh => oh.product_type == _orderHistory.product_type
                    && oh.product_name == _orderHistory.product_name).FirstOrDefault() != null)
                    return new DBResponse<OrderHistoryViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<OrderHistoryViewModel>
                {
                    Description = "Error!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<OrderHistoryViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<OrderHistoryViewModel> DeleteOHistory(OrderHistoryViewModel _orderHistory)
        {
            try
            {
                dbase.Database
                    .ExecuteSqlRaw($"call CancelOrder('{_orderHistory.id}', " +
                    $"'{_orderHistory.seller_alias}')");

                if (dbase.Order_history
                    .Where(oh => oh.id == _orderHistory.id)
                    .AsNoTracking()
                    .FirstOrDefault() == null)
                    return new DBResponse<OrderHistoryViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<OrderHistoryViewModel>
                {
                    Description = "Error!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<OrderHistoryViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<OrderHistoryViewModel> EditOHistory(OrderHistoryViewModel _orderHistory)
        {
            try
            {
                var OrderHistory = new Order_history
                {
                    id = _orderHistory.id,
                    product_type = _orderHistory.product_type,
                    product_name = _orderHistory.product_name,
                    order_date = _orderHistory.order_date,
                    cost = _orderHistory.cost,
                    seller_alias = _orderHistory.seller_alias
                };
                dbase.Order_history.Update(OrderHistory);
                dbase.SaveChanges();
                if (dbase.Order_history
                    .Where(oh => oh.id == _orderHistory.id).AsNoTracking().FirstOrDefault() == OrderHistory)
                    return new DBResponse<OrderHistoryViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<OrderHistoryViewModel>
                {
                    Description = "Error!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<OrderHistoryViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<OrderHistoryPageViewModel> GetOHistories()
        {
            try
            {
                var OHistories = (from oh in dbase.Order_history
                                  select new OrderHistoryViewModel
                                  {
                                      id = oh.id,
                                      product_type = oh.product_type,
                                      product_name = oh.product_name,
                                      order_date = oh.order_date,
                                      cost = oh.cost,
                                      seller_alias = oh.seller_alias
                                  }).ToList();
                var Sellers = (from p in dbase.Profiles
                               select new SelectListItem
                               {
                                   Value = p.alias,
                                   Text = p.alias
                               }).ToList();

                if (OHistories.Count != 0)
                    return new DBResponse<OrderHistoryPageViewModel>
                    {
                        Data = new OrderHistoryPageViewModel
                        {
                            OHistoryList = OHistories,
                            SellerList = Sellers
                        },
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<OrderHistoryPageViewModel>
                {
                    Data = new OrderHistoryPageViewModel
                    {
                        SellerList = Sellers
                    },
                    Description = "НЕ ПРОДАНО ЖОДНОГО ТОВАРУ",
                    StatusCode = StatusCodes.DataIsEmpty
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<OrderHistoryPageViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }
    }
}
