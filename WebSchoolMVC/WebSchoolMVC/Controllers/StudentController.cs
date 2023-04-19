using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Enum;
using WebSchoolMVC.Domain.Response;
using WebSchoolMVC.Models;

namespace WebSchoolMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentInterface _repo;

        public StudentController(IStudentInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var groups = await _repo.GetGroupsForSelection();
            return PartialView("Create", new StudentViewModel
            {
                GroupSelectList = groups
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Create(new Student
                {
                    Fullname = student.Fullname,
                    Address = student.Address,
                    Group_Id = student.Group_Id,
                    MobileNumber = student.MobileNumber,
                    Login = student.Login,
                    Password = student.Password,
                    Status = student.Status
                });

                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }

            student.GroupSelectList = _repo.GetGroupsForSelection(student.Group_Id.ToString()).Result;
            return PartialView("Create", student);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var OperationResult = await _repo.GetById(Id);
            var student = new StudentViewModel
            {
                Id = OperationResult.Data.Id,
                Fullname = OperationResult.Data.Fullname,
                Address = OperationResult.Data.Address,
                MobileNumber = OperationResult.Data.MobileNumber,
                Login = OperationResult.Data.Login,
                Password = OperationResult.Data.Password,
                Status = OperationResult.Data.Status,
                GroupSelectList = await _repo.GetGroupsForSelection(OperationResult.Data.Group_Id.ToString())
            };
            return PartialView("Update", student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(StudentViewModel student)
        {
            DBResponse<Student> dbResponse = new();
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Edit(new Student
                {
                    Id = student.Id,
                    Fullname = student.Fullname,
                    Address = student.Address,
                    Group_Id = student.Group_Id,
                    MobileNumber = student.MobileNumber,
                    Login = student.Login,
                    Password = student.Password,
                    Status = student.Status
                });
                dbResponse = (DBResponse<Student>)OperationResult;
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            student.GroupSelectList = await _repo.GetGroupsForSelection(dbResponse.Data.Group_Id.ToString());
            return PartialView("Update", student);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var OperationResult = await _repo.GetById(Id);
            return PartialView("Delete", OperationResult.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Student student)
        {
            var OperationResult = await _repo.Delete(student);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(StudentOrderBy studentOrderByCondition)
        {
            var OperationResult = await _repo.GetAll();
            if (OperationResult.IsSuccessful)
            {
                var ResultList = OperationResult.Data.ToList();
                switch (studentOrderByCondition)
                {
                    case StudentOrderBy.FullnameAsc:
                        {
                            return View(ResultList.OrderBy(x => x.Fullname).ToList());
                        }
                    case StudentOrderBy.FullnameDesc:
                        {
                            return View(ResultList.OrderByDescending(x => x.Fullname).ToList());
                        }
                    case StudentOrderBy.GroupAsc:
                        {
                            return View(ResultList.OrderBy(x => x.Group.Title).ToList());
                        }
                    case StudentOrderBy.GroupDesc:
                        {
                            return View(ResultList.OrderByDescending(x => x.Group.Title).ToList());
                        }
                    default:
                        {
                            return View(ResultList);
                        }
                }
            }
            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            return OperationResult.IsSuccessful ? OperationResult.Data is not null ? View(OperationResult.Data) : RedirectToAction("GetAll") : BadRequest();


            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpGet]
        public IActionResult StudentLogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentLogIn(LogInViewModel userdata)
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
