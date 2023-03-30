using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class BinModel : PageModel
    {
        private readonly IBinInterface _repo;
        public List<BinViewModel> SelectedProducts { get; set; }

        [BindProperty]
        public BinViewModel SelectedProduct { get; set; }

        public BinModel(IBinInterface repo)
        {
            _repo = repo;
        }

        public async Task OnGet(int Id)
        {
            SelectedProducts = (List<BinViewModel>)await _repo.GetAll();
        }

        public async Task OnGetByUserId(int Id)
        {
            SelectedProducts = (List<BinViewModel>)await _repo.GetByUserId(
                int.Parse(User.FindFirst(ClaimTypes.Sid).Value)
                );
        }

        public IActionResult OnPostCreate(int prod_id)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("LogIn");
            var newProd = new BinViewModel
            {
                Owner = new UserViewModel
                {
                    Id = int.Parse(User.FindFirst(ClaimTypes.Sid).Value)
                },
                Product = new ProductViewModel
                {
                    Id = prod_id
                }
            };
            if (_repo.Create(newProd))
                return RedirectToPage("/Product");
            else
                return BadRequest();
        }

        public IActionResult OnGetToOrder()
        {
            SelectedProducts = (List<BinViewModel>)_repo.GetByUserId(
                int.Parse(User.FindFirst(ClaimTypes.Sid).Value)).Result;
            var NewOrder = new OrdersViewModel
            {
                Owner = new UserViewModel { Id = int.Parse(User.FindFirst(ClaimTypes.Sid).Value) },
                ProductsIn = SelectedProducts.Where(x => x.Owner.Id == int.Parse(User.FindFirst(ClaimTypes.Sid).Value)).ToList().Select(x => x.Product).ToList()
            };

            TempData["NewOrder"] = JsonConvert.SerializeObject(NewOrder).ToString();

            return RedirectToPage("Orders", "Create");
        }

        public IActionResult OnGetDelete(int Id)
        {
            if (_repo.Delete(new BinViewModel { Id = Id }))
                return RedirectToPage("Bin");
            else
                return BadRequest();
        }

        public IActionResult OnGetDeleteAllByUserId(int UserId)
        {
            if (_repo.DeleteAllByUserId(UserId))
                return RedirectToPage("Bin");
            else
                return BadRequest();
        }
    }
}
