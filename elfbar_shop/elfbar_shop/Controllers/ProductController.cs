using elfbar_shop.DAL.Services.Implements;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wangkanai.Detection.Services;

namespace elfbar_shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDetectionService detectionService;
        private readonly IProductService Service;

        public ProductController(IProductService _service, IDetectionService detection)
        {
            Service = _service;
            detectionService = detection;
        }
        
        public async Task<IActionResult> CreateProduct(ProductViewModel _product)
        {
            if (!ModelState.IsValid)
            {
                var DataFromDB = await Service.GetProducts();
                if (DataFromDB.StatusCode == Domain.Response.StatusCodes.OK)
                {
                    return View("GetProducts", DataFromDB.Data);
                }
            }
            var Response = Service.CreateProduct(_product);
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                TempData["success"] = Response.Description;
                return RedirectToAction("GetProducts");
            }
            TempData["failure"] = Response.Description;
            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public async Task <IActionResult> EditProduct(int id)
        {
            var Response = await Service.GetProducts();
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                Response.Data.Product = Response.Data.ProductList
                    .Where(r => r.id == id).FirstOrDefault();
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditProduct(product);
                if (Response.StatusCode == Domain.Response.StatusCodes.OK)
                {
                    TempData["success"] = Response.Description;
                    return RedirectToAction("GetProducts");
                }
                TempData["failure"] = Response.Description;
                return View(product);
            }
            return View(product);
        }

        public async Task<IActionResult> GetProducts(string GetByType)
        {
            var Response = await Service.GetProducts();
            if (detectionService?.Device.Type == Wangkanai.Detection.Models.Device.Mobile)
            {
                Response.Data.IsMobileDevice = true;
            }
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                if (GetByType != null)
                {
                    Response.Data.ProductList = Response.Data.ProductList
                        .Where(r => r.type_name == GetByType).ToList();
                    return View(Response.Data);
                }
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }
    }
}
