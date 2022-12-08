using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ServicesService Service;

        public ServicesController(ServicesService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateService() => View();
        [HttpPost]
        public IActionResult CreateServices(ServicesViewModel _service)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateServices(_service);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View();
                return RedirectToAction("Error");
            }
            return View();
        }
        public IActionResult DeleteServices(ServicesViewModel _service)
        {
            var Response = Service.DeleteServices(_service);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View();
            return RedirectToAction("Error");
        }
        [HttpGet]
        public IActionResult EditServices() => View();
        [HttpPost]
        public IActionResult EditServices(ServicesViewModel _service)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditServices(_service);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View();
                return RedirectToAction("Error");
            }
            return View();
        }
        public IActionResult GetServices(ServicesViewModel _service)
        {
            var Response = Service.GetServicess();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r=>r.id == _service.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetServicess()
        {
            var Response = Service.GetServicess();
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
