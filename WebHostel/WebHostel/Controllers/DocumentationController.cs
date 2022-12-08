using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Models;
using WebHostel.Services.Implements;

namespace WebHostel.Controllers
{
    public class DocumentationController : Controller
    {
        private readonly DocumentationService Service;

        public DocumentationController(DocumentationService _service)
        {
            Service = _service;
        }
        [HttpGet]
        public IActionResult CreateDocumentation() => View();
        [HttpPost]
        public IActionResult CreateDocumentation
            (DocumentationViewModel doc)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.CreateDocumentation(doc);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return View();
                }
                TempData["failure"] = Response.Description.ToString();
                return View();
            }
            return View();
        }
        public IActionResult DeleteDocumentation
            (DocumentationViewModel doc)
        {
            var Response = Service.DeleteDocumentation(doc);
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                TempData["success"] = Response.Description.ToString();
                return RedirectToAction("GetDcumentations");
            }
            TempData["failure"] = Response.Description.ToString();
            return RedirectToAction("GetDcumentations");
        }
        [HttpGet]
        public IActionResult EditDocumentation(int id)
        {
            var Response = Service.GetDocumentations();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == id));
            return RedirectToAction("Error");
        }
        [HttpPost]
        public IActionResult EditDocumentation
            (DocumentationViewModel doc)
        {
            if (ModelState.IsValid)
            {
                var Response = Service.EditDocumentation(doc);
                if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                {
                    TempData["success"] = Response.Description.ToString();
                    return RedirectToAction("GetDcumentation", doc);
                }
                TempData["failure"] = Response.Description.ToString();
                return View(doc);
            }
            return View();
        }
        public IActionResult GetDocumentation
            (DocumentationViewModel doc)
        {
            var Response = Service.GetDocumentations();
            if (Response.StatusCode == Domain.Enum.StatusCode.OK)
                return View(Response.Data.FirstOrDefault(r => r.id == doc.id));
            return RedirectToAction("Error");
        }
        public IActionResult GetDocumentations
            ()
        {
            var Response = Service.GetDocumentations();
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
