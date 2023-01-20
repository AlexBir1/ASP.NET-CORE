
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Controllers
{
    public class TypesController : Controller
    {
        private readonly ITypesService Service;

        public TypesController(ITypesService _service)
        {
            Service = _service;
        }

        public async Task<IActionResult> CreateType(TypesViewModel type)
        {
            if (!ModelState.IsValid)
            {
                var DataFromDB = await Service.GetTypes();
                if(DataFromDB.StatusCode == Domain.Response.StatusCodes.OK)
                {
                    return View("GetTypes", DataFromDB.Data);
                }
            }
            var Response = Service.CreateType(type);
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                TempData["success"] = Response.Description;
                return View("GetTypes");
            }
            TempData["failure"] = Response.Description;
            return View("GetTypes");
        }

        [HttpGet]
        public IActionResult DeleteType(int id, string title)
        {
            var Type = new TypesViewModel
            {
                id = id,
                title = title
            };
            return PartialView("_DeleteTypePartial", Type);
        }

        [HttpPost]
        public IActionResult DeleteType(TypesViewModel type)
        {
            var Response = Service.DeleteType(type);
            if (Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                TempData["success"] = Response.Description;
                return View("GetTypes");
            }
            TempData["failure"] = Response.Description;
            return View("GetTypes");
        }

        public async Task<IActionResult> GetTypes()
        {
            var Response = await Service.GetTypes();
            if(Response.StatusCode == Domain.Response.StatusCodes.OK)
            {
                return View(Response.Data);
            }
            return View();
        }
    }
}
