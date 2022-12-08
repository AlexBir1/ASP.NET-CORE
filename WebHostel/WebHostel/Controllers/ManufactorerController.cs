using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class ManufactorerController : Controller
    {
        private readonly ManufactorerService Service;

        public ManufactorerController(ManufactorerService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateManufactorer() => View();
        [HttpPost]
        public IActionResult CreateManufactorer
            (ManufactorerViewModel manufactorer)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateManufactorer(manufactorer);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetManufactorers");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(manufactorer);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditManufactorer(int id)
        {
            var Response = Service.GetManufactorers();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditManufactorer
            (ManufactorerViewModel manufactorer)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditManufactorer(manufactorer);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetManufactorer", "Manufactorer", manufactorer);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(manufactorer);
            }
            return View();
        }
        public IActionResult DeleteManufactorer
            (ManufactorerViewModel manufactorer)
        {
            var Response = Service.DeleteManufactorer(manufactorer);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetManufactorers", "Manufactorer");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetManufactorers", "Manufactorer");
        }
        public IActionResult GetManufactorer
            (ManufactorerViewModel manufactorer)
        {
            var Response = Service.GetManufactorers();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == manufactorer.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetManufactorers
            ()
        {
            var Response = Service.GetManufactorers();
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
