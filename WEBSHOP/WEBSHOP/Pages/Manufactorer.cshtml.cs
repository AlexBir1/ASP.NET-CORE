using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Helpers;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class ManufactorerModel : PageModel
    {
        public List<ManufactorerViewModel> MnfList { get; set; }
        private readonly IManufactorerInterface _repo;

        public ManufactorerModel(IManufactorerInterface repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            MnfList = (List<ManufactorerViewModel>) await _repo.GetAll();
            return Page();
        }
        public ActionResult OnGetToCreate()
        {
            return Partial("_CreateManufactorer");
        }
        public IActionResult OnPostCreate(ManufactorerViewModel _mnf)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Create(_mnf))
                    return new PartialViewResult
                    {
                        ViewName = "_CreateManufactorer",
                        ViewData = new ViewDataDictionary<ManufactorerViewModel>(ViewData, _mnf)
                    };
                else
                    return BadRequest();
            }
            MnfList = (List<ManufactorerViewModel>) _repo.GetAll().Result;
            return new PartialViewResult
            {
                ViewName = "_CreateManufactorer",
                ViewData = new ViewDataDictionary<ManufactorerViewModel>(ViewData, _mnf)
            };
        }
        public async Task<IActionResult> OnGetToEdit(int Id)
        {
            var Manufactorer = await _repo.GetById(Id);
            return Partial("_EditManufactorer", Manufactorer);
        }
        public IActionResult OnPostEdit(ManufactorerViewModel _mnf)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Edit(_mnf))
                    return RedirectToPage("/Manufactorer");
                else
                    return BadRequest();
            }
            return Partial("_EditManufactorer", _mnf);
        }
        public IActionResult OnGetToDelete(int Id)
        {
            var _mnf = _repo.GetById(Id).Result;
            Dictionary<string, string> FieldAndValue = DictionaryFromModel.GetDictionaryFromModel(typeof(ManufactorerViewModel), _mnf);
            return Partial("_DeleteConfirmation", new DeleteViewModel { ObjName = "Manufactorer", ObjInfo = FieldAndValue });
        }
        public void OnGetDelete(int Id)
        {
            var _mnf = new ManufactorerViewModel {Id = Id };
            if (_repo.Delete(_mnf))
            {
                MnfList = (List<ManufactorerViewModel>)_repo.GetAll().Result;
            }
            else
                BadRequest();
        }
    }
}
