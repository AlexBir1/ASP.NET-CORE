using elfbar_shop.DAL.Services.Implements;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elfbar_shop.Models;
using elfbar_shop.DAL.Services.Interfaces;

namespace elfbar_shop.Controllers
{
    public class LaughController : Controller
    {
        private readonly ILaughService Service;

        public LaughController(ILaughService _service)
        {
            Service = _service;
        }
        public IActionResult CreateL(LaughViewModel laugh)
        {
            var Response = Service.CreateL(laugh);
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                TempData["success"] = Response.Description;
                return RedirectToAction("GetLs");
            }
            TempData["failure"] = Response.Description;
            return RedirectToAction("GetLs");
        }
        public IActionResult DeleteL(LaughViewModel laugh)
        {
            var Response = Service.DeleteL(laugh);
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                TempData["success"] = Response.Description;
                return RedirectToAction("GetLs");
            }
            TempData["failure"] = Response.Description;
            return RedirectToAction("GetLs");
        }
        public IActionResult GetLs()
        {
            var Response = Service.GetLs();
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }
    }
}
