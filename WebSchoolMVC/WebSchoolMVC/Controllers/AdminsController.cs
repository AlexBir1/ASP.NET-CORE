using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Models;

namespace WebSchoolMVC.Controllers
{
    public class AdminsController : Controller
    {
        private readonly IAdminsInterface _repo;

        public AdminsController(IAdminsInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetById(int Id)
        {

            var OperationResult = await _repo.GetById(Id);

            return OperationResult.IsSuccessful ? OperationResult.Data is not null ? View(OperationResult.Data) : RedirectToAction("GetAll") : BadRequest();

        }

        [HttpGet]
        public IActionResult AdminLogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminLogIn(LogInViewModel userdata)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.FindAndAuthenticate(userdata.Login, userdata.Password);
                if (OperationResult.IsSuccessful)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new System.Security.Claims.ClaimsPrincipal(OperationResult.Data));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", OperationResult.Description);
                return View(userdata);
            }
            return View(userdata);
        }
    }
}
