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
    public class SpendsController : Controller
    {
        private readonly ISpendsService Service;

        public SpendsController(ISpendsService _service)
        {
            Service = _service;
        }
        public IActionResult CreateSpend(SpendsViewModel spend)
        {
            var Response = Service.CreateSpend(spend);
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                TempData["success"] = Response.Description;
                return RedirectToAction("GetSpends");
            }
            TempData["failure"] = Response.Description;
            return RedirectToAction("GetSpends");
        }

        public async Task<IActionResult> GetSpends()
        {
            var Response = await Service.GetSpends();
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }
    }
}
