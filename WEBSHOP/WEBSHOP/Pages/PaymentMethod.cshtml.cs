using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Helpers;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class PaymentMethodModel : PageModel
    {
        public List<PaymentMethodViewModel> paymentMethodsList { get; set; }
        public PaymentMethodViewModel paymentMethod { get; set; }

        private readonly IPaymentMethodInterface _repo;

        public PaymentMethodModel(IPaymentMethodInterface repo)
        {
            _repo = repo;
        }

        public async Task OnGetAsync()
        {
            paymentMethodsList = (List<PaymentMethodViewModel>)await _repo.GetByUserId(int.Parse(User.FindFirst(ClaimTypes.Sid).Value));
        }

        public IActionResult OnPost(PaymentMethodViewModel _paymentMethod)
        {
            return RedirectToPage("/PaymentMethod");
        }

        public IActionResult OnGetToCreate()
        {
            return Partial("_CreatePMethod");
        }

        public IActionResult OnPostCreate(PaymentMethodViewModel _paymentMethod)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Create(_paymentMethod))
                    return new PartialViewResult()
                    {
                        ViewName = "_CreatePMethod",
                        ViewData = new ViewDataDictionary<PaymentMethodViewModel>(ViewData, _paymentMethod)
                    };
                else
                    return BadRequest();
            }
            else
                return new PartialViewResult()
                {
                    ViewName = "_CreatePMethod",
                    ViewData = new ViewDataDictionary<PaymentMethodViewModel>(ViewData, _paymentMethod)
                };
        }

        public IActionResult OnGetToDelete(int Id)
        {
            var _paymentMethod = _repo.GetById(Id).Result;
            Dictionary<string, string> FieldAndValue = DictionaryFromModel.GetDictionaryFromModel(typeof(PaymentMethodViewModel), _paymentMethod);
            return Partial("_DeleteConfirmation", new DeleteViewModel { ObjName = "Payment method", ObjInfo = FieldAndValue });
        }

        public IActionResult OnGetDelete(int Id)
        {
            var _paymentMethod = new PaymentMethodViewModel { Id = Id };
            if (_repo.Delete(_paymentMethod))
                return RedirectToPage("/Types");
            else
                return BadRequest();
        }
    }
}
