using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersService hservice;

        public CustomersController(CustomersService _hservice)
        {
            hservice = _hservice;
        }

        public IActionResult CreateCustomers(CustomersViewModel hos)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.CreateCustomers(hos);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    return View();
                }
                ModelState.AddModelError("", Response.Description);
            }
            return View();
        }

        public IActionResult DeleteCustomers(CustomersViewModel hos)
        {
            var Response = hservice.DeleteCustomers(hos);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetCustomers");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetCustomers");
        }
        [HttpGet]
        public IActionResult EditCustomers(int id)
        {
            var Response = hservice.GetCustomerss();
            if(Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.FirstOrDefault(r=>r.id == id));
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public IActionResult EditCustomers(CustomersViewModel hos)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.EditCustomers(hos);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetCustomers", "Customers", hos);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(hos);
            }
            return View();
        }

        public IActionResult GetCustomerss()
        {
            var Response = hservice.GetCustomerss();
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

        public IActionResult GetCustomers(CustomersViewModel hos)
        {
            var Response = hservice.GetCustomers(hos.phone);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public IActionResult Log_in() => View();

        [HttpPost]
        public async Task<IActionResult> Log_in(LoginViewModel hos)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.Log_in(hos);
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
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(CRegisterViewModel hos)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.Register(hos);
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
    }
}
