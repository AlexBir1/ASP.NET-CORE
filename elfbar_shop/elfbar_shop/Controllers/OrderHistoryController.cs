using elfbar_shop.DAL.Services.Implements;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elfbar_shop.Models;
using elfbar_shop.DAL.Services.Interfaces;

namespace elfbar_shop.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly IOrderHistoryService Service;

        public OrderHistoryController(IOrderHistoryService _service)
        {
            Service = _service;
        }

        [HttpGet]
        public IActionResult CreateOHistory(string product_type, string product_name, int cost, DateTime order_date, string seller_alias)
        {
            var OHistory = new OrderHistoryViewModel
            {
                product_type = product_type,
                product_name = product_name,
                cost = cost,
                order_date = order_date,
                seller_alias = seller_alias
            };
            return PartialView("_CreateOHistoryPartial", OHistory);
        }
        [HttpPost]
        public IActionResult CreateOHistory(OrderHistoryViewModel order)
        {
            var Response = Service.CreateOHistory(order);
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return PartialView("_CreateOHistoryPartial", order);
            }
            ModelState.AddModelError("", Response.Description);
            return PartialView("_CreateOHistoryPartial", order);
        }

        public IActionResult GetOHistories(string GetBySeller)
        {
            var Response = Service.GetOHistories();
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                if(GetBySeller == null)
                    return View(Response.Data);

                Response.Data.OHistoryList = Response.Data.OHistoryList
                    .Where(r => r.seller_alias == GetBySeller).ToList();
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }

        public IActionResult DeleteOHistory(OrderHistoryViewModel order)
        {
            var Response = Service.DeleteOHistory(order);
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return RedirectToAction("GetOHistories", "OrderHistory");
            }
            ModelState.AddModelError("", Response.Description);
            return RedirectToAction("GetOHistories", "OrderHistory");
        }
    }
}
