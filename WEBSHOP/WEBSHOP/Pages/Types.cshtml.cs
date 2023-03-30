using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.Helpers;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class TypesModel : PageModel
    {
        public List<TypesViewModel> TypesList { get; set; }

        [BindProperty]
        public TypesViewModel Type { get; set; }

        private readonly ITypesInterface _repo;

        public TypesModel(ITypesInterface repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            TypesList = (List<TypesViewModel>)await _repo.GetAll();
            return Page();
        }

        public IActionResult OnGetToEdit(TypesViewModel type)
        {
            return Partial("_TypesEdit", type);
        }

        public IActionResult OnGetToCreate()
        {
            return Partial("_TypeCreate");
        }

        public IActionResult OnGetToDelete(int Id)
        {
            var type = _repo.GetById(Id).Result;
            Dictionary<string, string> FieldAndValue = DictionaryFromModel.GetDictionaryFromModel(typeof(TypesViewModel),type);
            return Partial("_DeleteConfirmation", new DeleteViewModel { ObjName = "Type", ObjInfo = FieldAndValue });
        }

        public IActionResult OnPostCreate(TypesViewModel type)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Create(type))
                    return new PartialViewResult
                    {
                        ViewName = "_TypeCreate",
                        ViewData = new ViewDataDictionary<TypesViewModel>(ViewData, type)
                    };
                else
                    return BadRequest();
            }
            TypesList = (List<TypesViewModel>)_repo.GetAll().Result;
            return new PartialViewResult
            {
                ViewName = "_TypeCreate",
                ViewData = new ViewDataDictionary<TypesViewModel>(ViewData, type)
            };
        }

        public IActionResult OnPostEdit(TypesViewModel _type)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Edit(_type))
                    return new PartialViewResult
                    {
                        ViewName = "_TypesEdit",
                        ViewData = new ViewDataDictionary<TypesViewModel>(ViewData, _type)
                    };
                else
                return BadRequest();
            }
            TypesList = (List<TypesViewModel>)_repo.GetAll().Result;
            return new PartialViewResult
            {
                ViewName = "_TypesEdit",
                ViewData = new ViewDataDictionary<TypesViewModel>(ViewData, _type)
            };
        }

        public IActionResult OnGetDelete(int Id)
        {
            var type = new TypesViewModel { Id = Id };
            if (_repo.Delete(type))
                return RedirectToPage("/Types");
            else 
                return BadRequest();
            
        }
    }
}
