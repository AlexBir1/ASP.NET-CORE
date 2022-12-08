using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class WordersController : Controller
    {
        private readonly WordersService Service;

        public WordersController(WordersService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateWOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateWOrder(wordersViewModel worder)
        {
                var Response = Service.CreateWOrder(worder);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetWOrders");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(worder);
        }
        [HttpGet]
        public IActionResult EditWOrder(int id)
        {
            var Response = Service.GetWOrders();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditWOrder(wordersViewModel worder)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditWOrder(worder);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetWOrder",worder);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(worder);
            }
            return View();
        }
        public IActionResult DeleteWOrder(wordersViewModel worder)
        {
            var Response = Service.DeleteWOrder(worder);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetWOrders");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetWOrders");
        }
        public IActionResult GetWOrder(wordersViewModel worder)
        {
            var Response = Service.GetWOrders();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == worder.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetWOrders()
        {
            var Response = Service.GetWOrders();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.ToList());
            else
            {
                ModelState.AddModelError("", Response.Description);
                return View();
            }
        }
        public IActionResult UpdateOrderWStatus(wordersViewModel worder)
        {
            var Response = Service.UpdateOrderWStatus(worder);
            if(Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetWOrders", "Worders");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetWOrders", "Worders");
        }
    }
}
