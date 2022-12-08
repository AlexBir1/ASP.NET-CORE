using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class ServicesHistoryController : Controller
    {
        private readonly Services_historyService Service;

        public ServicesHistoryController(Services_historyService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateSHistory() => View();
        [HttpPost]
        public IActionResult CreateSHistory(Services_historyViewModel services_History)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateServices_history(services_History);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetSHistories");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(services_History);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditSHistory(int id)
        {
            var Response = Service.GetServices_historys();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditSHistory(Services_historyViewModel services_History)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditServices_history(services_History);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetSHistory", services_History);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(services_History);
            }
            return View();
        }
        public IActionResult DeleteSHistory(Services_historyViewModel services_History)
        {
            var Response = Service.DeleteServices_history(services_History);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetSHistories");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetSHistories");
        }
        public IActionResult GetSHistory(Services_historyViewModel services_History)
        {
            var Response = Service.GetServices_historys();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == services_History.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetSHistories()
        {
            var Response = Service.GetServices_historys();
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
