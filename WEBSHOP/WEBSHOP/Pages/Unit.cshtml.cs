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
    public class UnitModel : PageModel
    {
        public List<UnitViewModel> UnitList { get; set; }

        private readonly IUnitInterface _repo;

        public UnitModel(IUnitInterface repo)
        {
            _repo = repo;
        }

        public async Task OnGetAsync()
        {
            UnitList = (List<UnitViewModel>) await _repo.GetAll();
        }
        public IActionResult OnGetToCreate()
        {
            return Partial("_UnitCreate");
        }
        public IActionResult OnPostCreate(UnitViewModel _unit)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Create(_unit))
                    return new PartialViewResult
                    {
                        ViewName = "_UnitCreate",
                        ViewData = new ViewDataDictionary<UnitViewModel>(ViewData, _unit)
                    };
                else
                    return BadRequest();
            }
            UnitList = (List<UnitViewModel>) _repo.GetAll().Result;
            return new PartialViewResult
            {
                ViewName = "_UnitCreate",
                ViewData = new ViewDataDictionary<UnitViewModel>(ViewData, _unit)
            };
        }
        public IActionResult OnGetToEdit(UnitViewModel _unit)
        {
            return Partial("_UnitEdit", _unit);
        }
        public IActionResult OnPostEdit(UnitViewModel _unit)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Edit(_unit))
                    return new PartialViewResult
                    {
                        ViewName = "_UnitEdit",
                        ViewData = new ViewDataDictionary<UnitViewModel>(ViewData, _unit)
                    };
                else
                    return BadRequest();
            }
            return new PartialViewResult
            {
                ViewName = "_UnitEdit",
                ViewData = new ViewDataDictionary<UnitViewModel>(ViewData, _unit)
            };
        }
        public IActionResult OnGetToDelete(int Id)
        {
            var unit = _repo.GetById(Id).Result;
            Dictionary<string, string> FieldAndValue = DictionaryFromModel.GetDictionaryFromModel(typeof(UnitViewModel), unit);
            return Partial("_DeleteConfirmation", new DeleteViewModel { ObjName = "Unit", ObjInfo = FieldAndValue });
        }
        public IActionResult OnGetDelete(int Id)
        {
            var _unit = new UnitViewModel { Id = Id };
            if (_repo.Delete(_unit))
                return RedirectToPage("/Unit");
            else
                return BadRequest();
        }
    }
}
