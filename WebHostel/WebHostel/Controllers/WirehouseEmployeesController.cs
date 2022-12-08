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
    public class Wirehouse_employeesController : Controller
    {
        private readonly WirehouseEmployeesService Service;

        public Wirehouse_employeesController(WirehouseEmployeesService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateWEmployee
            ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateWEmployee
            (Wirehouse_employeesViewModel wirehouse_Employee)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateWEmployee(wirehouse_Employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View();
                return RedirectToAction("Error");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditWEmployee(int id)
        {
            var Response = Service.GetWEmployees();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditWEmployee
            (Wirehouse_employeesViewModel wirehouse_Employee)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditWEmployee(wirehouse_Employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetWEmployee", wirehouse_Employee);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(wirehouse_Employee);
            }
            return View();
        }
        public IActionResult DeleteWEmployee(Wirehouse_employeesViewModel wirehouse_Employee)
        {
            var Response = Service.DeleteWEmployee(wirehouse_Employee);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetWEmployees");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetWEmployees");
        }
        public IActionResult GetWEmployee(Wirehouse_employeesViewModel wirehouse_Employee)
        {
            var Response = Service.GetWEmployees();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == wirehouse_Employee.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetWEmployees()
        {
            var Response = Service.GetWEmployees();
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
        public async Task<IActionResult> Register(WERegisterViewModel _employee)
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
