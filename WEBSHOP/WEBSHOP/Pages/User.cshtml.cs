using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WEBSHOP.DAL.Repositories.Interfaces;
using WEBSHOP.Domain.Helpers;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Pages
{
    public class UserModel : PageModel
    {
        public List<UserViewModel> UsersInfo { get; set; }

        [BindProperty]
        public UserViewModel UserInfo { get; set; }

        private readonly IUserInterface _repo;

        public UserModel(IUserInterface repo)
        {
            _repo = repo;
        }

        public async Task OnGetAsync()
        {
            if (User.IsInRole("Admin"))
                UsersInfo = (List<UserViewModel>)await _repo.GetAll();

            UserInfo = await _repo.GetById(int.Parse(User.FindFirst(ClaimTypes.Sid).Value));
        }

        public IActionResult OnPostChangeProfile(UserViewModel _user)
        {
            if (_repo.Edit(_user))
                return RedirectToPage("/User");
            else
                return BadRequest();
        }

        public IActionResult OnGetToDelete(int Id)
        {
            var user = _repo.GetById(Id).Result;
            Dictionary<string, string> FieldAndValue = DictionaryFromModel.GetDictionaryFromModel(typeof(UserViewModel), user);
            return Partial("_DeleteConfirmation", new DeleteViewModel { ObjName = "User", ObjInfo = FieldAndValue });
        }

        public IActionResult OnPostDeleteProfileByAdmin(UserViewModel _user)
        {
            if (_repo.Delete(_user))
                return RedirectToPage("/User");
            else
                return BadRequest();
        }

        public IActionResult OnGetDataToCreatePartial()
        {
            List<UnitViewModel> units = new();
            _repo.GetDataForCUPartials(ref units);
            return Partial("_CreateUser", new UserCUViewModel
            {
                Units = new SelectList(units, "Id", "Title")
            });
        }

        public IActionResult OnGetDataToEditPartial(UserViewModel _user)
        {
            List<UnitViewModel> units = new();
            _repo.GetDataForCUPartials(ref units);
            _user = _repo.GetById(_user.Id).Result;
            if (_user.MyUnit != null)
                return Partial("_EditUser", new UserCUViewModel
                {
                    Fullname = _user.Fullname,
                    Phone = _user.Phone,
                    Login = _user.Login,
                    Password = _user.Password,
                    MyUnit = new UnitViewModel
                    {
                        Id = _user.MyUnit.Id
                    },
                    Status = _user.Status,
                    ShippingAddress = _user.ShippingAddress,
                    Units = new SelectList(units, "Id", "Title", _user.MyUnit.Id)
                });
            return Partial("_EditUser", new UserCUViewModel
            {
                Fullname = _user.Fullname,
                Phone = _user.Phone,
                Login = _user.Login,
                Password = _user.Password,
                Status = _user.Status,
                ShippingAddress = _user.ShippingAddress,
                Units = new SelectList(units, "Id", "Title","0")
            });
        }

        public IActionResult OnPostEditProfileByAdmin(UserCUViewModel _user)
        {
            List<UnitViewModel> units = new();
            _repo.GetDataForCUPartials(ref units);
            if (ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel
                {
                    Id = _user.Id,
                    Fullname = _user.Fullname,
                    Phone = _user.Phone,
                    Login = _user.Login,
                    Password = _user.Password,
                    MyUnit = new UnitViewModel
                    {
                        Id = _user.Id
                    },
                    Status = _user.Status,
                    ShippingAddress = _user.ShippingAddress
                };
                if (_repo.Edit(user))
                    return new PartialViewResult
                    {
                        ViewName = "_EditUser",
                        ViewData = new ViewDataDictionary<UserCUViewModel>(ViewData)
                    };
                else
                    return BadRequest();
            }
            return new PartialViewResult
            {
                ViewName = "_EditUser",
                ViewData = new ViewDataDictionary<UserCUViewModel>(ViewData, new UserCUViewModel
                {
                    Fullname = _user.Fullname,
                    Phone = _user.Phone,
                    Login = _user.Login,
                    Password = _user.Password,
                    MyUnit = new UnitViewModel
                    {
                        Id = _user.Id
                    },
                    Status = _user.Status,
                    ShippingAddress = _user.ShippingAddress,
                    Units = new SelectList(units, "Id", "Title", _user.MyUnit.Id)
                })
            };
        }

        public IActionResult OnPostCreateProfileByAdmin(UserCUViewModel _user)
        {
            List<UnitViewModel> units = new();
            _repo.GetDataForCUPartials(ref units);
            if (ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel
                {
                    Fullname = _user.Fullname,
                    Phone = _user.Phone,
                    Login = _user.Login,
                    Password = _user.Password,
                    MyUnit = new UnitViewModel
                    {
                        Id = _user.Id
                    },
                    Status = _user.Status,
                    ShippingAddress = _user.ShippingAddress
                };
                if (_repo.Create(user))
                    return new PartialViewResult
                    {
                        ViewName = "_CreateUser",
                        ViewData = new ViewDataDictionary<UserCUViewModel>(ViewData)
                    };
                else
                    return BadRequest();
            }
            return new PartialViewResult
            {
                ViewName = "_CreateUser",
                ViewData = new ViewDataDictionary<UserCUViewModel>(ViewData, new UserCUViewModel
                {
                    Fullname = _user.Fullname,
                    Phone = _user.Phone,
                    Login = _user.Login,
                    Password = _user.Password,
                    MyUnit = new UnitViewModel
                    {
                        Id = _user.Id
                    },
                    Status = _user.Status,
                    ShippingAddress = _user.ShippingAddress,
                    Units = new SelectList(units, "Id", "Title", _user.MyUnit.Id)
                })
            };
        }
    }
}
