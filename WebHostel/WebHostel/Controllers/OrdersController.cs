using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersService hservice;

        public OrdersController(OrdersService _hservice)
        {
            hservice = _hservice;
        }
        [HttpGet]
        public IActionResult CreateOrder() => View();
        [HttpPost]
        public IActionResult CreateOrder(OrdersViewModel order)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.CreateOrders(order);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetOrders");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(order);
            }
            return View();
        }
        public IActionResult DeleteOrder(OrdersViewModel order)
        {
            var Response = hservice.DeleteOrders(order);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetOrders");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetOrders");
        }
        [HttpGet]
        public IActionResult EditOrder(int id) 
        {
            var Response = hservice.GetOrders();
            if(Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.FirstOrDefault(r=>r.id == id));
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditOrder(OrdersViewModel order)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.EditOrders(order);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetOrder", order);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(order);
            }
            return View();
        }
        public IActionResult GetOrder(OrdersViewModel order)
        {
            var Response = hservice.GetOrders();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.FirstOrDefault(r=>r.id == order.id));
            }
            return RedirectToAction("Error");
        }
        public IActionResult GetOrders()
        {
            var Response = hservice.GetOrders();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.ToList());
            }
            else
            {
                ModelState.AddModelError("", Response.Description);
                return View();
            }
        }
        public IActionResult UpdateStatusEOrder(OrdersViewModel order)
        {
            var Response = hservice.UpdateOrderEStatus(order);
            if(Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetOrders", "Orders");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetOrders", "Orders");
        }
        public IActionResult UpdateStatusOrder(OrdersViewModel order)
        {
            var Response = hservice.UpdateOrderStatus(order);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetOrders", "Orders");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetOrders", "Orders");
        }
    }
}
