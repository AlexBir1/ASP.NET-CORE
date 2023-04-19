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
    public class RoomController : Controller
    {
        private readonly IRoomInterface _repo;

        public RoomController(IRoomInterface repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var OperationResult = await _repo.GetAll();

            if (OperationResult.IsSuccessful)
                return (OperationResult.Data is not null) ? View(OperationResult.Data) : RedirectToAction("GetAll");

            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
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
        public async Task<IActionResult> Create(RoomViewModel room)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Create(new Room
                {
                    Number = room.Number,
                    Floor = (int)room.Floor
                });
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            return PartialView("Create", room);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var OperationResult = await _repo.GetById(Id);

            if (OperationResult.IsSuccessful)
                return PartialView("Update", new RoomViewModel
                {
                    Id = OperationResult.Data.Id,
                    Number = OperationResult.Data.Number,
                    Floor = OperationResult.Data.Floor,
                    Teacher_Id = OperationResult.Data.Teacher_Id
                });

            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoomViewModel room)
        {
            if (ModelState.IsValid)
            {
                var OperationResult = await _repo.Edit(new Room
                {
                    Id = room.Id,
                    Number = room.Number,
                    Floor = (int)room.Floor,
                    Teacher_Id = room.Teacher_Id
                });
                return PartialView("_OperationDetailsPartial", new OperationViewModel
                {
                    Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                    Message = OperationResult.Description
                });
            }
            return PartialView("Update", room);
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
        public async Task<IActionResult> Delete(Room room)
        {
            var OperationResult = await _repo.Delete(room);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpGet]
        public IActionResult AddCaretaker(int Id, int Teacher_Id)
        {
            var OperationResult = _repo.AddCaretaker(Id, Teacher_Id);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }

        [HttpGet]
        public IActionResult RemoveCaretaker(int Id)
        {
            var OperationResult = _repo.RemoveCaretaker(Id);
            return PartialView("_OperationDetailsPartial", new OperationViewModel
            {
                Status = OperationResult.IsSuccessful ? OperationStatus.Succeeded : OperationStatus.Failed,
                Message = OperationResult.Description
            });
        }
    }
}
