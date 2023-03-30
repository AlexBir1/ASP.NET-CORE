using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.Enums;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        [Required(ErrorMessage = "Empty field")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string ShippingAddress { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Empty field")]
        public string Password { get; set; }

        private readonly IUserInterface _repo;

        public RegisterModel(IUserInterface repo)
        {
            _repo = repo;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ExistingUsers = (List<UserViewModel>)await _repo.GetAll();
                if (!ExistingUsers.Exists(u => u.Phone == Phone || u.Login == Login))
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new System.Security.Claims.ClaimsPrincipal(_repo.AuthenticateUser(new UserViewModel
                        {
                            Fullname = Fullname,
                            Phone = Phone,
                            ShippingAddress = ShippingAddress,
                            Login = Login,
                            Password = Password
                        })));

                    return RedirectToPage("/Index");
                }
                ModelState.AddModelError("", "The user with similar login or mobile number already exists");
                return Page();
            }
            return Page();
        }
    }
}
