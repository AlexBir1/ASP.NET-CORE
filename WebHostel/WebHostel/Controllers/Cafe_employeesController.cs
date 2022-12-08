using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class Cafe_employeesController : Controller
    {
        private readonly CafeEmployeesService Service;

        public Cafe_employeesController(CafeEmployeesService _service)
        {
            Service = _service;
        }

        [HttpGet]
        public IActionResult CreateCEmployee() => View();
        [HttpPost]
        public IActionResult CreateCEmployee(Cafe_employeesViewModel cafe_Employee)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateCafeEmployee(cafe_Employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View();
                return RedirectToAction("Error");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditCEmployee(string phone) 
        {
            var Response = Service.GetCafeEmployees();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(s => s.phone == phone));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditCEmployee(Cafe_employeesViewModel cafe_Employee)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditCafeEmployee(cafe_Employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetCEmployee", "Cafe_employees", cafe_Employee);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(cafe_Employee);
            }
            return View();
        }
        public IActionResult DeleteCEmployee(Cafe_employeesViewModel cafe_Employee)
        {
            var Response = Service.DeleteCafeEmployee(cafe_Employee);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCEmployees", "Cafe_employees");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetCEmployees", "Cafe_employees");
        }
        public IActionResult GetCEmployee(Cafe_employeesViewModel cafe_Employee)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.GetCafeEmployees();
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View(Response.Data.FirstOrDefault(r=>r.id == cafe_Employee.id));
                return RedirectToAction("Error");
            }
            return View();
        }
        public IActionResult GetCEmployees()
        {
            var Response = Service.GetCafeEmployees();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.ToList());
            else
            {
                ModelState.AddModelError("", Response.Description);
                return View();
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Log_in()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CERegisterViewModel _employee)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.Register(_employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new System.Security.Claims.ClaimsPrincipal(Response.Data));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", Response.Description);
            }
            return View(_employee);
        }
        [HttpPost]
        public async Task<IActionResult> Log_in(LoginViewModel _employee)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.Log_in(_employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new System.Security.Claims.ClaimsPrincipal(Response.Data));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", Response.Description);
            }
            return View();
        }

        public async Task<IActionResult> Log_out()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
