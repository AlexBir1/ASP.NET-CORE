using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingService bservice;

        public BookingController(BookingService _bservice)
        {
            bservice = _bservice;
        }
        [HttpGet]
        public IActionResult CreateBooking(int room_num)
        {
            return View(new BookingViewModel
            {
                room_num = room_num
            });
        }
        [HttpPost]
        public IActionResult CreateBooking(BookingViewModel _booking)
        {
            var Response = bservice.CreateBooking(_booking);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("Index", "Home");
            }
            TempData["failure"] = Response.Description.ToString();
            return View(_booking);
        }

        public IActionResult DeleteBooking(BookingViewModel _booking)
        {
            var Response = bservice.DeleteBooking(_booking);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("Index", "Home");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult EditBooking() => View();
        [HttpPost]
        public IActionResult EditBooking(BookingViewModel _booking)
        {
            var Response = bservice.EditBooking(_booking);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetBooking", "Booking",_booking);
            }
            TempData["failure"] = Response.Description.ToString();
            return View(_booking);
        }

        public IActionResult GetBooking(BookingViewModel _booking)
        {
            var Response = bservice.GetBooking(_booking.customer_num);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data);
            }
            return RedirectToAction("Error");
        }

        public IActionResult GetBookings()
        {
            var Response = bservice.GetBookings();
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
    }
}
