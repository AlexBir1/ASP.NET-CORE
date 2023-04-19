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
    public class TimetableController : Controller
    {
        private readonly ITimetableInterface _repo;

        public TimetableController(ITimetableInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var OperationResult = await _repo.GetAll();
            return OperationResult.IsSuccessful && OperationResult.Data is not null ? View(OperationResult.Data) : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var OperationResult = await _repo.GetById(Id);
            return OperationResult.IsSuccessful ? OperationResult.Data is not null ? View(OperationResult.Data) : RedirectToAction("GetAll") : BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var GroupsOperationResult = await _repo.GetGroupSelectList();
            var SubjectsOperationResult = await _repo.GetSubjectSelectList();
            var RoomsOperationResult = await _repo.GetRoomSelectList();

            if (!GroupsOperationResult.IsSuccessful || !SubjectsOperationResult.IsSuccessful || !RoomsOperationResult.IsSuccessful)
                return BadRequest();

            var OperationResult = await Task.FromResult(PartialView("Create", new TimetableViewModel
            {
                GroupSelectList = GroupsOperationResult.Data,
                SubjectSelectList = SubjectsOperationResult.Data,
                RoomSelectList = RoomsOperationResult.Data,
            }));

            return OperationResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TimetableViewModel timetable)
        {
            var GroupsOperationResult = await _repo.GetGroupSelectList();
            var SubjectsOperationResult = await _repo.GetSubjectSelectList();
            var RoomsOperationResult = await _repo.GetRoomSelectList();

            if (!GroupsOperationResult.IsSuccessful || !SubjectsOperationResult.IsSuccessful || !RoomsOperationResult.IsSuccessful)
                return BadRequest();

            timetable.GroupSelectList = GroupsOperationResult.Data;
            timetable.SubjectSelectList = SubjectsOperationResult.Data;
            timetable.RoomSelectList = RoomsOperationResult.Data;

            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Create(new Timetable
                {
                    Topic = timetable.Topic,
                    StartDateTime = timetable.StartDateTime,
                    EndDateTime = timetable.EndDateTime,
                    Subject_Id = timetable.Subject_Id,
                    Group_Id = timetable.Group_Id,
                    Room_Id = timetable.Room_Id
                });
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            return PartialView("Create", timetable);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            if (OperationResult.IsSuccessful)
            {
                var GroupsOperationResult = _repo.GetGroupSelectList(OperationResult.Data.Group_Id).Result;
                var SubjectsOperationResult = _repo.GetSubjectSelectList(OperationResult.Data.Subject_Id).Result;
                var RoomsOperationResult = _repo.GetRoomSelectList(OperationResult.Data.Room_Id).Result;

                if (!GroupsOperationResult.IsSuccessful || !SubjectsOperationResult.IsSuccessful || !RoomsOperationResult.IsSuccessful)
                    return BadRequest();

                return PartialView("Update", new TimetableViewModel
                {
                    Id = OperationResult.Data.Id,
                    Topic = OperationResult.Data.Topic,
                    StartDateTime = OperationResult.Data.StartDateTime,
                    EndDateTime = OperationResult.Data.EndDateTime,
                    GroupSelectList = GroupsOperationResult.Data,
                    SubjectSelectList = SubjectsOperationResult.Data,
                    RoomSelectList = RoomsOperationResult.Data
                });
            }
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromForm]TimetableViewModel timetable)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Edit(new Timetable
                {
                    Id = timetable.Id,
                    Topic = timetable.Topic,
                    StartDateTime = timetable.StartDateTime,
                    EndDateTime = timetable.EndDateTime,
                    Group_Id = timetable.Group_Id,
                    Room_Id = timetable.Subject_Id,
                    Subject_Id = timetable.Room_Id
                });
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            var GroupsOperationResult = await _repo.GetGroupSelectList(timetable.Group_Id);
            var SubjectsOperationResult = await _repo.GetSubjectSelectList(timetable.Subject_Id);
            var RoomsOperationResult = await _repo.GetRoomSelectList(timetable.Room_Id);

            if (!GroupsOperationResult.IsSuccessful || !SubjectsOperationResult.IsSuccessful || !RoomsOperationResult.IsSuccessful)
                return BadRequest();

            timetable.GroupSelectList = GroupsOperationResult.Data;
            timetable.SubjectSelectList = SubjectsOperationResult.Data;
            timetable.RoomSelectList = RoomsOperationResult.Data;

            return PartialView("Update", timetable);
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
        public async Task<ActionResult> Delete(Timetable timetable)
        {
            var OperationResult = await _repo.Delete(timetable);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }
    }
}
