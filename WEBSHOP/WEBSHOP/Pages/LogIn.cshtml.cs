using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Empty field")]
        public string Login { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Empty field")]
        public string Password { get; set; }

        private readonly IUserInterface _repo;

        public LogInModel(IUserInterface repo)
        {
            _repo = repo;
        }
        public void OnGet() { }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ExistingUsers = (List<UserViewModel>)await _repo.GetAll();
                if (ExistingUsers.Exists(u => u.Login == Login && u.Password == Password))
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new System.Security.Claims.ClaimsPrincipal(_repo.AuthenticateUser(new UserViewModel { Login = Login, Password = Password })));
                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError("", "Incorrect login or password");
                return Page();
            }
            return Page();
        }
    }
}
