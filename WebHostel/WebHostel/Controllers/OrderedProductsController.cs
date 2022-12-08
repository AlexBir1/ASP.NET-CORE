using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class OrderedProductsController : Controller
    {
        private readonly OrderedProductsService Service;

        public OrderedProductsController(OrderedProductsService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateOProduct() => View();
        [HttpPost]
        public IActionResult CreateOProduct
            (ordered_productsViewModel ordered_Products)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateOProduct(ordered_Products);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetOProducts");
                }
                TempData["failure"] = Response.Description.ToString();
                return View(ordered_Products);
            }
            return View();
        }
        public IActionResult DeleteOProduct
            (ordered_productsViewModel ordered_Products)
        {
            var Response = Service.DeleteOProduct(ordered_Products);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetOProducts");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetOProducts");
        }
        [HttpGet]
        public IActionResult EditOProduct(int id)
        {
            var Response = Service.GetOProducts();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditOProduct
            (ordered_productsViewModel ordered_Products)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditOProduct(ordered_Products);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetOProduct", ordered_Products);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(ordered_Products);
            }
            return View();
        }
        public IActionResult GetOProduct
           (ordered_productsViewModel ordered_Products)
        {
            var Response = Service.GetOProducts();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == ordered_Products.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetOProducts
           ()
        {
            var Response = Service.GetOProducts();
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
