using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class CafeController : Controller
    {
        private readonly CafeService Service;

        public CafeController(CafeService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateCafe() => View();
        [HttpPost]
        public IActionResult CreateCafe(CafeViewModel Cafe)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateCafe(Cafe);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("Index", "Home");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(Cafe);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditCafe(int id)
        {
            var Response = Service.GetCafes();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditCafe(CafeViewModel Cafe)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditCafe(Cafe);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetCafe", "Cafe", Cafe);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(Cafe);
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteCafe(CafeViewModel Cafe)
        {
            var Response = Service.DeleteCafe(Cafe);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCafes", "Cafe", Cafe);
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetCafe", "Cafe", Cafe);
        }
        [HttpGet]
        public IActionResult GetCafe(CafeViewModel Cafe)
        {
            var Response = Service.GetCafes();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r=>r.title == Cafe.title));
            return RedirectToAction("Error");
        }
        [HttpGet]
        public IActionResult GetCafes()
        {
            var Response = Service.GetCafes();
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
