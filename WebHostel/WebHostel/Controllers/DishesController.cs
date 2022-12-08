using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class DishesController : Controller
    {
        private readonly DishesService Service;

        public DishesController(DishesService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateDish() => View();
        [HttpPost]
        public IActionResult CreateDish(DishesViewModel dish)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateDishes(dish);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View();
                return RedirectToAction("Error");
            }
            return View();
        }
        public IActionResult DeleteDish(DishesViewModel dish)
        {
            var Response = Service.DeleteDishes(dish);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View();
            return RedirectToAction("Error");
        }
        [HttpGet]
        public IActionResult EditDish(int id)
        {
            var Response = Service.GetDishess();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditDish(DishesViewModel dish)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditDishes(dish);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                    return View();
                return RedirectToAction("Error");
            }
            return View();
        }
        public IActionResult GetDish(DishesViewModel dish)
        {
            var Response = Service.GetDishess();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == dish.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetDishes()
        {
            var Response = Service.GetDishess();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.ToList());
            else
            {
                ModelState.AddModelError("", Response.Description);
                return View();
            }
        }
    }
}
