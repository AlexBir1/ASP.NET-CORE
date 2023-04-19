using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;
using WebSchoolMVC.Models;

namespace WebSchoolMVC.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournalInterface _repo;

        public JournalController(IJournalInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> Create(int Student_Id)
        {
            var OperationResult = await _repo.GetSubjectsByTeacherId(int.Parse(User.FindFirst(ClaimTypes.Sid).Value));
            return PartialView("Create", new JournalViewModel
            {
                Student_Id = Student_Id,
                Subjects = new SelectList(OperationResult.Data, "Id", "Title")
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JournalViewModel newNote)
        {
            if (!ModelState.IsValid)
                return PartialView("Create", newNote);

            var OperationResult = await _repo.Create(new Journal 
            { 
                Student_Id = newNote.Student_Id, 
                Subject_Id = newNote.Subject_Id,
                Mark = newNote.Mark,
                MarkingDate = DateTime.Today
            });
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int Student_Id)
        {
            IBaseResponse<IEnumerable<Journal>> OperationResult;

            if (Student_Id != 0)
                OperationResult = await _repo.GetAllByStudentId(Student_Id);
            else
                OperationResult = await _repo.GetAll();

            if (OperationResult.IsSuccessful)
                return (OperationResult.Data is not null) ? View(OperationResult.Data) : RedirectToAction("GetAll");

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
        public async Task<IActionResult> Delete(Journal note)
        {
            var OperationResult = await _repo.Delete(note);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }
    }
}
