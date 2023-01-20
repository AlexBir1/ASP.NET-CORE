using elfbar_shop.DAL.Services.Implements;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Controllers
{
    public class SellInfoController : Controller
    {
        private readonly ISell_InfoService Service;

        public SellInfoController(ISell_InfoService _service)
        {
            Service = _service;
        }

        public IActionResult GetSInfo()
        {
            var Response = Service.GetSell_info();
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }

        [HttpGet]
        public IActionResult EditSInfo()
        {
            var Response = Service.GetSell_info();
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }
        [HttpGet]
        public IActionResult SetRBalancePrev()
        {
            return PartialView("_SetRBalancePartial");
        }
        [HttpPost]
        public IActionResult SetRBalance()
        {
            var Response = Service.SetRBalance();
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return RedirectToAction("GetSInfo", Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return RedirectToAction("GetSInfo");
        }
    }
}
