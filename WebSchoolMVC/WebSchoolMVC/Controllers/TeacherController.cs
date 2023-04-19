using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Enum;
using WebSchoolMVC.Models;

namespace WebSchoolMVC.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherInterface _repo;

        public TeacherController(ITeacherInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(TeacherOrderBy teacherOrderByCondition)
        {
            var OperationResult = await _repo.GetAll();
            if (OperationResult.IsSuccessful)
            {
                var ResultList = OperationResult.Data.ToList();
                switch (teacherOrderByCondition)
                {
                    case TeacherOrderBy.FullnameAsc:
                        {
                            return View(ResultList.OrderBy(x => x.Fullname).ToList());
                        }
                    case TeacherOrderBy.FullnameDesc:
                        {
                            return View(ResultList.OrderByDescending(x => x.Fullname).ToList());
                        }
                    default:
                        {
                            return View(ResultList.ToList());
                        }
                }
            }
            return BadRequest();

        }

        [HttpGet]
        public async Task<ActionResult> GetById(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            return OperationResult.IsSuccessful ? OperationResult.Data is not null ? View(OperationResult.Data) : RedirectToAction("GetAll") : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var OperationResult = await Task.FromResult(PartialView("Create"));
            return OperationResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Create(new Teacher
                {
                    Fullname = teacher.Fullname,
                    Address = teacher.Address,
                    MobileNumber = teacher.MobileNumber,
                    Login = teacher.Login,
                    Password = teacher.Password,
                    Status = (int)UserStatus.Teacher

                });
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            return PartialView("Create", teacher);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            if (OperationResult.IsSuccessful)
                return PartialView("Update", new TeacherViewModel 
                {
                    Id = OperationResult.Data.Id,
                    Fullname = OperationResult.Data.Fullname,
                    Address = OperationResult.Data.Address,
                    MobileNumber = OperationResult.Data.MobileNumber,
                    Login = OperationResult.Data.Login,
                    Password = OperationResult.Data.Password
                });

            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Edit(new Teacher
                {
                    Id = teacher.Id,
                    Fullname = teacher.Fullname,
                    Address = teacher.Address,
                    MobileNumber = teacher.MobileNumber,
                    Login = teacher.Login,
                    Password = teacher.Password,
                    Status = (int)UserStatus.Teacher

                });
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            return PartialView("Update", teacher);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            if (OperationResult.IsSuccessful)
                return PartialView("Delete", OperationResult.Data);

            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Teacher teacher)
        {
            var OperationResult = await _repo.Delete(teacher);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpGet]
        public IActionResult TeacherLogIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> TeacherLogIn(LogInViewModel userdata)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.FindAndAuthenticate(userdata.Login, userdata.Password);
                if (OperationResult.IsSuccessful)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new System.Security.Claims.ClaimsPrincipal(OperationResult.Data));
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", OperationResult.Description);
                return View(userdata);
            }
            return View(userdata);
        }
    }
}
