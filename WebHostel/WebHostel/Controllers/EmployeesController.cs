using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesService employeesService;

        public EmployeesController(EmployeesService _service)
        {
            employeesService = _service;
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var employee = employeesService.GetEmployees()
                .Data.FirstOrDefault(e => e.id == id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult CreateEmployee(EmployeesViewModel _employee)
        {
            if (ModelState.IsValid)
            {
                var Response = employeesService.CreateEmployee(_employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View();
                }
                ModelState.AddModelError("", Response.Description);
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditEmployee(EmployeesViewModel _employee)
        {
            if (ModelState.IsValid)
            {
                var Response = employeesService.EditEmployee(_employee);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return View(_employee);
                }
                ModelState.AddModelError("", Response.Description);
            }
            return View();
        }

        public IActionResult DeleteEmployee(EmployeesViewModel _employee)
        {
            var Response = employeesService.DeleteEmployee(_employee);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetEmployees");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetEmployee", _employee);
        }

        public IActionResult GetEmployee(EmployeesViewModel _employee)
        {
            var Response = employeesService.GetEmployees();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.FirstOrDefault(r => r.id == _employee.id));
            }
            return RedirectToAction("Error");
        }

        public IActionResult GetEmployees()
        {
            var Response = employeesService.GetEmployees();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.ToList());
            }
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
        public async Task<IActionResult> Register(ERegisterViewModel _employee)
        {
            if (ModelState.IsValid)
            {
                var Response = employeesService.Register(_employee);
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
                var Response = employeesService.Log_in(_employee);
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
