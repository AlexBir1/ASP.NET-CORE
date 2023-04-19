using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Models;

namespace WebSchoolMVC.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupInterface _repo;

        public GroupController(IGroupInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var OperationResult = await _repo.GetAll();

            if (OperationResult.IsSuccessful)
                return (OperationResult.Data is not null) ? View(OperationResult.Data) : RedirectToAction("GetAll");


            return BadRequest();
        }

        // GET: HomeController1/Details/5
        [HttpGet]
        public async Task<ActionResult> GetById(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            return OperationResult.IsSuccessful ? OperationResult.Data is not null ? View(OperationResult.Data) : RedirectToAction("GetAll") : BadRequest();

        }

        // GET: HomeController1/Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var OperationResult = await Task.FromResult(PartialView("Create"));
            return OperationResult;
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GroupViewModel group)
        {

            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Create(new Group
                {
                    Title = group.Title
                });

                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }

            return PartialView("Create", group);
        }

        // GET: HomeController1/Edit/5
        [HttpGet]
        public async Task<ActionResult> Update(int Id)
        {
            var OperationResult = await _repo.GetById(Id);
            var group = new GroupViewModel
            {
                Id = OperationResult.Data.Id,
                Title = OperationResult.Data.Title,
                Teacher_Id = OperationResult.Data.Teacher_Id.HasValue ? OperationResult.Data.Teacher_Id : null
            };
            return PartialView("Update", group);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(GroupViewModel group)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Edit(new Group
                {
                    Id = group.Id,
                    Title = group.Title,
                    Teacher_Id = group.Teacher_Id.HasValue ? group.Teacher_Id : null
                });

                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }

            return PartialView("Update", group);
        }

        // GET: HomeController1/Delete/5
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

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Group group)
        {
            var OperationResult = await _repo.Delete(group);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }
    }
}
