using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Histories()
        {
            return View();
        }
        public IActionResult Products()
        {
            return View();
        }
    }
}
