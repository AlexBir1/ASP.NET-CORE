using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class ChecksHistoryController : Controller
    {
        private readonly ChecksHistoryService Service;

        public ChecksHistoryController(ChecksHistoryService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateCHistory() => View();
        [HttpPost]
        public IActionResult CreateCHistory
            (Checks_historyViewModel checks_History)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateChecksHistory(checks_History);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetCheckss", "Checks");
                }
                TempData["failure"] = Response.Description.ToString();
                return RedirectToAction("GetCheckss", "Checks");
            }
            return View();
        }
        public IActionResult DeleteCHistory
            (Checks_historyViewModel checks_History)
        {
            var Response = Service.DeleteChecksHistory(checks_History);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCHistories", "ChecksHistory");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetCHistories", "ChecksHistory");
        }
        [HttpGet]
        public IActionResult EditCHistory(int id)
        {
            var Response = Service.GetChecksHistories();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditCHistory
            (Checks_historyViewModel checks_History)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditChecksHistory(checks_History);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetCHistory", "ChecksHistory", checks_History);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(checks_History);
            }
            return View();
        }
        public IActionResult GetCHistory
            (Checks_historyViewModel checks_History)
        {
            var Response = Service.GetChecksHistories();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r=>r.id == checks_History.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetCHistories
            ()
        {
            var Response = Service.GetChecksHistories();
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
