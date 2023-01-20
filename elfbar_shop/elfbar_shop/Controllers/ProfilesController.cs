using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elfbar_shop.DAL.Services.Implements;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace elfbar_shop.Controllers
{
    public class ProfilesController : Controller
    {
        [BindProperty(SupportsGet = true)]
        public string SearchStr { get; set; }

        private readonly IProfilesService Service;

        public ProfilesController(IProfilesService _service)
        {
            Service = _service;
        }

        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            var Response = Service.GetProfiles();
            int cur_id = id;
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                var Account = Response.Data.Where(r => r.id == cur_id).FirstOrDefault();
                return View(Account);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult EditProfile(ProfilesViewModel profile)
        {
            var Response = Service.EditProfile(profile);
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return RedirectToAction("GetProfile", profile);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }

        public IActionResult GetProfile(ProfilesViewModel _profile)
        {
            var Response = Service.GetProfiles();
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return View(Response.Data.FirstOrDefault(r=>r.login == _profile.login));
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }

        [HttpGet]
        public IActionResult Log_in() => View();

        [HttpPost]
        public async Task<IActionResult> Log_in(LoginViewModel hos)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.Log_in(hos);
                if (Response.StatusCode == Domain.Response.StatusCodes.OK)
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
