using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class OrdersHistoryController : Controller
    {
        private readonly OrdersHistoryService Service;

        public OrdersHistoryController(OrdersHistoryService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateOHistory() => View();
        [HttpPost]
        public IActionResult CreateOHistory
            (orders_historyViewModel orders_History)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateOHistory(orders_History);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetOHistories");
                }
                TempData["failure"] = Response.Description.ToString();
                return RedirectToAction("GetOHistories");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditOHistory
            (int id)
        {
            var Response = Service.GetOHistories();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditOHistory
            (orders_historyViewModel orders_History)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditOHistory(orders_History);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetOHistory",orders_History);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(orders_History);
            }
            return View();
        }
        public IActionResult DeleteOHistory
            (orders_historyViewModel orders_History)
        {
            var Response = Service.DeleteOHistory(orders_History);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetOHistories");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetOHistories");
        }
        public IActionResult GetOHistory
            (orders_historyViewModel orders_History)
        {
            var Response = Service.GetOHistories();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == orders_History.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetOHistories()
        {
            var Response = Service.GetOHistories();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.ToList());
            else
            {
                ModelState.AddModelError("", Response.Description);
                return View();
            }
        }
    }
}
