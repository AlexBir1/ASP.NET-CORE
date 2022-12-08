using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Implements
{
    public class RoomsService : IRoomsService
    {
        private readonly RoomsRepository RoomsRepository;

        public RoomsService(RoomsRepository _RoomsRepository)
        {
            RoomsRepository = _RoomsRepository;
        }

        public IBaseResponse<RoomsViewModel> CreateRooms(RoomsViewModel _Rooms)
        {
            var BaseRes = new DBResponse<RoomsViewModel>();
            try
            {
                RoomsRepository.Create(_Rooms);
                var new_Rooms = RoomsRepository.GetAll()
                    .FirstOrDefault(r=>r.num == _Rooms.num 
                    && r.hostel_name == _Rooms.hostel_name);
                if (new_Rooms != null)
                {
                    BaseRes.Data = new_Rooms;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<RoomsViewModel>
                {
                    Description = $"[CreateRooms] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<RoomsViewModel> DeleteRooms(RoomsViewModel _Rooms)
        {
            var BaseRes = new DBResponse<RoomsViewModel>();
            try
            {
                RoomsRepository.Delete(_Rooms);
                var new_Rooms = RoomsRepository.GetAll()
                    .FirstOrDefault(r => r.id == _Rooms.id);
                if (new_Rooms == null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<RoomsViewModel>
                {
                    Description = $"[DeleteRooms] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<RoomsViewModel> EditRooms(RoomsViewModel _Rooms)
        {
            var BaseRes = new DBResponse<RoomsViewModel>();
            try
            {
                RoomsRepository.Edit(_Rooms, _Rooms.id);
                var new_hostel = RoomsRepository.GetAll()
                    .FirstOrDefault(r => r.id == _Rooms.id);
                if (new_hostel == _Rooms)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<RoomsViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<RoomsViewModel> GetRooms(string Rooms_num, string hostel_name)
        {
            var BaseRes = new DBResponse<RoomsViewModel>();
            try
            {
                var Rooms = RoomsRepository.Get(Rooms_num, hostel_name);
                if (Rooms != null)
                {
                    BaseRes.Data = Rooms;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<RoomsViewModel>
                {
                    Description = $"[GetRooms] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<RoomsViewModel>> GetRoomss()
        {
            var BaseRes = new DBResponse<IEnumerable<RoomsViewModel>>();
            try
            {
                var Roomss = RoomsRepository.GetAll();
                if (Roomss.Count() != 0)
                {
                    BaseRes.Data = Roomss;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<RoomsViewModel>>
                {
                    Description = $"[GetRoomss] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<RoomsViewModel>> GetRoomss(string hostel_name)
        {
            var BaseRes = new DBResponse<IEnumerable<RoomsViewModel>>();
            try
            {
                var Roomss = RoomsRepository.GetAll().Where(R=>R.hostel_name == hostel_name).ToList();
                if (Roomss.Count() != 0)
                {
                    BaseRes.Data = Roomss;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<RoomsViewModel>>
                {
                    Description = $"[GetRoomss] : {ex.Message}"
                };
            }
        }
    }
}
