using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;
using WebSchoolMVC.Models;

namespace WebSchoolMVC.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectInterface _repo;

        public SubjectController(ISubjectInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int Teacher_Id)
        {
            IBaseResponse<IEnumerable<Subject>> OperationResult;

            if (Teacher_Id != 0)
                OperationResult = await _repo.GetAllByTeacherId(Teacher_Id);
            else
                OperationResult = await _repo.GetAll();

                return OperationResult.IsSuccessful && (OperationResult.Data is not null) ? View(OperationResult.Data) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            return OperationResult.IsSuccessful ? OperationResult.Data is not null ? View(OperationResult.Data) : RedirectToAction("GetAll") : BadRequest();

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var OperationResult = await Task.FromResult(PartialView("Create"));
            return OperationResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectViewModel subject)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Create(new Subject
                {
                    Title = subject.Title
                });
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            return PartialView("Create", subject);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
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
        public async Task<IActionResult> Delete(Subject subject)
        {
            var OperationResult = await _repo.Delete(subject);

            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpGet]
        public async Task<IActionResult> AddTeacher(int Subject_Id, int Teacher_Id)
        {
            var OperationResult = await _repo.AddTeacher(Subject_Id, Teacher_Id);
            var GetSubjectResult = await _repo.GetById(Subject_Id);
            return OperationResult.IsSuccessful && GetSubjectResult.IsSuccessful ? RedirectToAction("GetById", "Subject", GetSubjectResult.Data) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveTeacher(int Subject_Id, int Teacher_Id)
        {
            var OperationResult = await _repo.RemoveTeacher(Subject_Id, Teacher_Id);
            var GetSubjectResult = await _repo.GetById(Subject_Id);
            return OperationResult.IsSuccessful && GetSubjectResult.IsSuccessful ? RedirectToAction("GetById", "Subject", GetSubjectResult.Data) : BadRequest();
        }
    }
}
