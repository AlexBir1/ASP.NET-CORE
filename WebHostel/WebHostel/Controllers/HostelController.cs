using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class HostelController : Controller
    {
        private readonly HostelService hservice;

        public HostelController(HostelService _hservice)
        {
            hservice = _hservice;
        }
        [HttpGet]
        public IActionResult CreateHostel() => View();
        [HttpPost]
        public IActionResult CreateHostel(HostelViewModel hos)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.CreateHostel(hos);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetHostels");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(hos);
            }
            return View();
        }

        public IActionResult DeleteHostel(HostelViewModel hos)
        {
            var Response = hservice.DeleteHostel(hos);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetHostels");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetHostels");
        }
        [HttpGet]
        public IActionResult EditHostel(int id) 
        {
            var Response = hservice.GetHostels();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditHostel(HostelViewModel hos)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.EditHostel(hos);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetHostel", hos);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(hos);
            }
            return View();
        }

        public IActionResult GetHostels()
        {
            var Response = hservice.GetHostels();
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

        public IActionResult GetHostel(HostelViewModel hos)
        {
            var Response = hservice.GetHostel(hos.title);
            if(Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
