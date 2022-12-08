using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService Service;

        public ProductsController(ProductsService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateProduct() => View();
        public IActionResult EditProduct(int id) 
        {
            var Response = Service.GetProducts();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.FirstOrDefault(r=>r.id==id));
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductsViewModel prod)
        {
            var Response = Service.CreateProduct(prod);
            if(Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description;
                return RedirectToAction("GetProducts", "Products");
            }
            TempData["failure"] = Response.Description;
            return RedirectToAction("GetProducts", "Products");
        }

        public IActionResult DeleteProduct(ProductsViewModel prod)
        {
            var Response = Service.DeleteProduct(prod);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description;
                return RedirectToAction("GetProducts", "Products");
            }
            TempData["failure"] = Response.Description;
            return RedirectToAction("GetProducts", "Products");
        }

        [HttpPost]
        public IActionResult EditProduct(ProductsViewModel prod)
        {
            var Response = Service.EditProduct(prod);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description;
                return RedirectToAction("GetProducts", "Products");
            }
            TempData["failure"] = Response.Description;
            return RedirectToAction("GetProducts", "Products");
        }
        public IActionResult GetProduct(ProductsViewModel prod)
        {
            return View();
        }
        public IActionResult GetProducts()
        {
            var Response = Service.GetProducts();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(Response.Data.ToList());
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }
    }
}
