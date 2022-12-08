using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class ChosenServicesController : Controller
    {
        private readonly ChosenServicesService Service;

        public ChosenServicesController(ChosenServicesService _service)
        {
            Service = _service;
        }

        public IActionResult CreateCService
            (ChosenServicesViewModel chosenService)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateChosenServices(chosenService);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetCServices");
                }
                TempData["failure"] = Response.Description.ToString();
                return RedirectToAction("GetServicess","Services");
            }
            return View();
        }
        public IActionResult DeleteCService
           (ChosenServicesViewModel chosenService)
        {
            var Response = Service.DeleteChosenServices(chosenService);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCServices");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetCServices");
        }
        [HttpGet]
        public IActionResult EditCService(int id)
        {
            var Response = Service.GetChosenServices();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditCService
           (ChosenServicesViewModel chosenService)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditChosenServices(chosenService);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetCService", "ChosenServices");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(chosenService);
            }
            return View();
        }
        public IActionResult GetCService
           (ChosenServicesViewModel chosenService)
        {
            var Response = Service.GetChosenServices();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == chosenService.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetCServices
           ()
        {
            var Response = Service.GetChosenServices();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.ToList());
            else 
            {
                ModelState.AddModelError("", Response.Description);
                return View();
            }
        }
        public IActionResult UpdateStatus
          (ChosenServicesViewModel chosenService)
        {
            var Response = Service.UpdateStatus(chosenService);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCServices", "ChosenServices");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetCServices", "ChosenServices");
        }
    }
}
