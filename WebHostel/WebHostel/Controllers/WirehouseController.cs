using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class WirehouseController : Controller
    {
        private readonly WirehouseService Service;

        public WirehouseController(WirehouseService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateWirehouse() => View();
        [HttpPost]
        public IActionResult CreateWirehouse(WirehouseViewModel wirehouse)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateWirehouse(wirehouse);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetWirehouses");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(wirehouse);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditWirehouse(int id)
        {
            var Response = Service.GetWirehouses();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditWirehouse(WirehouseViewModel wirehouse)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditWirehouse(wirehouse);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetWirehouse",wirehouse);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(wirehouse);
            }
            return View();
        }
        public IActionResult GetWirehouse(WirehouseViewModel wirehouse)
        {
            var Response = Service.GetWirehouses();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.title == wirehouse.title));
            return RedirectToAction("Error");
        }
        public IActionResult GetWirehouses()
        {
            var Response = Service.GetWirehouses();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.ToList());
            else
            {
                ModelState.AddModelError("", Response.Description);
                return View();
            }
        }
        public IActionResult DeleteWirehouse(WirehouseViewModel wirehouse)
        {
            var Response = Service.DeleteWirehouse(wirehouse);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetWirehouses");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetWirehouses");
        }
    }
}
