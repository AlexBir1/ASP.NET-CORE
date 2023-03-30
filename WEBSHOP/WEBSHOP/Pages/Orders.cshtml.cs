using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Helpers;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class OrdersModel : PageModel
    {
        public List<OrdersViewModel> orders { get; set; }

        [BindProperty]
        public OrdersViewModel order { get; set; }

        private readonly IOrdersInterface _repo;

        public OrdersModel(IOrdersInterface repo)
        {
            _repo = repo;
        }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Employee"))
                orders = (List<OrdersViewModel>)await _repo.GetAll();
            else if (User.IsInRole("Customer"))
                orders = (List<OrdersViewModel>)await _repo.GetAllByUserId(int.Parse(User.FindFirst(ClaimTypes.Sid).Value));
        }

        public IActionResult OnGetCreate()
        {
            OrdersViewModel o = new();
            JsonConvert.PopulateObject(TempData["NewOrder"].ToString(), o);
            if (_repo.Create(o))
                return RedirectToPage("Orders");
            return BadRequest();
        }

        public IActionResult OnGetToDelete(int Id)
        {
            var order = _repo.GetById(Id).Result;
            Dictionary<string, string> FieldAndValue = DictionaryFromModel.GetDictionaryFromModel(typeof(OrdersViewModel), order);
            return Partial("_DeleteConfirmation", new DeleteViewModel { ObjName = "Order", ObjInfo = FieldAndValue });
        }
        public IActionResult OnGetToStatusEdit(int Id)
        {
            var order = _repo.GetById(Id).Result;
            return Partial("_OrderStatusChanger", new OrdersViewModel 
            { 
                Id = order.Id, 
                Status = order.Status,
                DateCreate = order.DateCreate,
                FullCost = order.FullCost,
                Owner = new UserViewModel
                {
                    Id = order.Owner.Id,
                    Fullname = order.Owner.Fullname,
                    Phone = order.Owner.Phone
                }
            });
        }
        public IActionResult OnPostStatusEdit(OrdersViewModel order)
        {
            var _order = _repo.GetById(order.Id).Result;
            _order.Status = order.Status;
            if (_repo.Edit(_order))
                return RedirectToPage("Orders");
            return BadRequest();
        }
        public IActionResult OnGetRemoveProductFromOrder(int OrderId, int ProductId)
        {
            if (_repo.DeleteProductFromOrder(OrderId, ProductId))
            {
                orders = (List<OrdersViewModel>)_repo.GetAll().Result;
                return Page();
            }
            return BadRequest();
        }
        public IActionResult OnGetAddProductInOrder(int OrderId, int ProductId)
        {
            if (_repo.AddProductInOrder(OrderId, ProductId))
            {
                orders = (List<OrdersViewModel>)_repo.GetAll().Result;
                return RedirectToPage("Product");
            }
            return BadRequest();
        }
        public async Task<IActionResult> OnGetShowOrders()
        {
            orders = (List<OrdersViewModel>)await _repo.GetAll();
            return Partial("_OrdersDetailed", orders);
        }
    }
}
