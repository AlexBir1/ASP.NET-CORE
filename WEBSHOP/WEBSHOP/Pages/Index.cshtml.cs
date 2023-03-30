using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITypesInterface _typesRepo;

        [BindProperty]
        public List<TypesViewModel> TypesList { get; set; }

        public IndexModel(ITypesInterface typesRepo)
        {
            _typesRepo = typesRepo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            TypesList = (List<TypesViewModel>)await _typesRepo.GetAll();
            return Page();
        }

        public IActionResult OnGetMenu()
        {
            return Partial("");
        }

        public async Task<IActionResult> OnGetLogOut() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("Index");
        }
    }
}
