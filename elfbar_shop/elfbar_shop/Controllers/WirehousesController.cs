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
    public class WirehousesController : Controller
    {
        private readonly IDetectionService detectionService;
        private readonly IWirehousesService Service;

        public WirehousesController(IWirehousesService _service, IDetectionService detection)
        {
            Service = _service;
            detectionService = detection;
        }

        [HttpGet]
        public IActionResult EditW(int id, int isAllEdit)
        {
            var Response = Service.GetWs().Result;
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                Response.Data.Product = Response.Data.ProductList.Where(r => r.id == id).FirstOrDefault();
                Response.Data.isAllEdit = isAllEdit;
                return View(Response.Data);
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }

        [HttpPost]
        public IActionResult EditW(WirehousesPageViewModel wirehouse)
        {
            var prod = new WirehousesViewModel
            {
                id = wirehouse.id,
                type_name = wirehouse.type_name,
                title = wirehouse.title,
                quantity = wirehouse.quantity,
                cost = wirehouse.cost,
                owner_alias = wirehouse.owner_alias
            };
            if (ModelState.IsValid)
            {
                var Response = Service.EditW(prod);
                if (Response.StatusCode == Domain.Response.StatusCodes.OK)
                {
                    TempData["success"] = Response.Description;
                    return RedirectToAction("GetW", "Wirehouses");
                }
                ModelState.AddModelError("", Response.Description);
                return View(wirehouse);
            }
            return View(wirehouse);
        }

        public async Task<IActionResult> GetW(string GetByType, string GetByOwner)
        {
            var Response = await Service.GetWs();
            if (detectionService?.Device.Type == Wangkanai.Detection.Models.Device.Mobile)
            {
                Response.Data.IsMobileDevice = true;
            }
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                if (GetByOwner != null && GetByType == null)
                {
                    Response.Data.ProductList = Response.Data.ProductList
                       .Where(r => r.owner_alias == GetByOwner).ToList();
                    Response.Data.GetByOwner = GetByOwner;

                    return View(Response.Data);
                }
                else if (GetByOwner != null && GetByType != null)
                {
                    Response.Data.ProductList = Response.Data.ProductList
                       .Where(r => r.owner_alias == GetByOwner).ToList();
                    Response.Data.ProductList = Response.Data.ProductList
                       .Where(r => r.type_name == GetByType).ToList();
                    Response.Data.GetByOwner = GetByOwner;
                    return View(Response.Data);
                }
                else if (GetByOwner == null && GetByType != null)
                {
                    Response.Data.ProductList = Response.Data.ProductList
                       .Where(r => r.type_name == GetByType).ToList();
                    return View(Response.Data);
                }
                else
                {
                    return View(Response.Data);
                }
            }
            ModelState.AddModelError("", Response.Description);
            return View();
        }
    }
}
