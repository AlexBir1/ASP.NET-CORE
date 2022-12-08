using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class ChecksController : Controller
    {
        private readonly ChecksService Service;

        public ChecksController(ChecksService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateChecks(int room_num, DateTime checkin_date, string customer_num, int isBooked) 
        {
                return View( new ChecksViewModel 
                {
                    checkin_date = checkin_date,
                    rooms_num = room_num,
                    customer_num = customer_num,
                    isBooked = isBooked
                   
                });
        }
        [HttpPost]
        public IActionResult CreateChecks(ChecksViewModel check)
        {
            var Response = Service.CreateChecks(check);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCheckss", "Checks");
            }
            TempData["failure"] = Response.Description.ToString();
            return View(check);
            
        }
        public IActionResult DeleteChecks(ChecksViewModel check)
        {
            var Response = Service.DeleteChecks(check);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCheckss", "Checks");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetCheckss", "Checks");
        }
        [HttpGet]
        public IActionResult EditChecks(int id) 
        {
            var Response = Service.GetCheckss();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditChecks(ChecksViewModel check)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditChecks(check);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetChecks", "Checks", check);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(check);
            }
            return View();
        }
        public IActionResult GetChecks(ChecksViewModel check)
        {
            var Response = Service.GetCheckss();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == check.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetCheckss()
        {
            var Response = Service.GetCheckss();
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
