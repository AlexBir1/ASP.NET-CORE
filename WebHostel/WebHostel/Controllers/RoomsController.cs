using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomsService hservice;

        public RoomsController(RoomsService _hservice)
        {
            hservice = _hservice;
        }

        [HttpGet]
        public IActionResult CreateRooms()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRooms(RoomsViewModel _room)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.CreateRooms(_room);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetRoomss");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(_room);
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditRooms(int id)
        {
            var Response = hservice.GetRoomss();
            if(Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }

        [HttpPost]
        public IActionResult EditRooms(RoomsViewModel _room)
        {
            if (ModelState.IsValid)
            {
                var Response = hservice.CreateRooms(_room);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetRooms", _room);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(_room);
            }
            return View();
        }

        public IActionResult GetRoomss()
        {
            var Response = hservice.GetRoomss();
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

        public IActionResult GetRooms(RoomsViewModel _room)
        {
            var Response = hservice.GetRoomss();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.FirstOrDefault(r=>r.id==_room.id));
            }
            return RedirectToAction("Error");
        }

        public IActionResult DeleteRooms(RoomsViewModel _room)
        {
            var Response = hservice.DeleteRooms(_room);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetRoomss");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetRoomss");
        }
    }
}
