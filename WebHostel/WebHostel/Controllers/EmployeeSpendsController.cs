using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class EmployeeSpendsController : Controller
    {
        private readonly EmployeeSpendsService Service;

        public EmployeeSpendsController(EmployeeSpendsService _service)
        {
            Service = _service;
        }

        [HttpGet]
        public IActionResult CreateESpend() => View();
        [HttpPost]
        public IActionResult CreateESpend
            (Employee_spendsViewModel employee_Spends)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateEmployeeSpends(employee_Spends);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetESpends", "EmployeeSpends");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(employee_Spends);
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditESpend(int id)
        {
            var Response = Service.GetEmployeeSpends();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditESpend
            (Employee_spendsViewModel employee_Spends)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditEmployeeSpends(employee_Spends);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetESpend", "EmployeeSpends", employee_Spends);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(employee_Spends);
            }
            return View();
        }
        public IActionResult DeleteESpend
            (Employee_spendsViewModel employee_Spends)
        {
            var Response = Service.DeleteEmployeeSpends(employee_Spends);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetESpends", "EmployeeSpends");
            }
            TempData["failure"] = Response.Description.ToString();
            return View(employee_Spends);
        }
        public IActionResult GetESpend
            (Employee_spendsViewModel employee_Spends)
        {
            var Response = Service.GetEmployeeSpends();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == employee_Spends.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetESpends
            ()
        {
            var Response = Service.GetEmployeeSpends();
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
