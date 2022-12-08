using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Entity;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Implements
{
    public class HostelService : IHostelService
    {
        private readonly HostelRepository hostelRepository;

        public HostelService (HostelRepository _hostelRepository)
        {
            hostelRepository = _hostelRepository;
        }

        public IBaseResponse<HostelViewModel> CreateHostel(HostelViewModel _hostel)
        {
            var BaseRes = new DBResponse<HostelViewModel>();
            try
            {
                hostelRepository.Create(_hostel);
                var new_hostel = hostelRepository.GetAll()
                    .FirstOrDefault(h => h.title == _hostel.title);
                if (new_hostel != null)
                {
                    BaseRes.Data = new_hostel;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<HostelViewModel>
                {
                    Description = $"[GetHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<HostelViewModel> DeleteHostel(HostelViewModel _hostel)
        {
            var BaseRes = new DBResponse<HostelViewModel>();
            try
            {
                hostelRepository.Delete(_hostel);
                var old_hostel = hostelRepository.GetAll()
                    .FirstOrDefault(h => h.id == _hostel.id);
                if (old_hostel == null)
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
                return new DBResponse<HostelViewModel>
                {
                    Description = $"[GetHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<HostelViewModel> EditHostel(HostelViewModel _hostel)
        {
            var BaseRes = new DBResponse<HostelViewModel>();
            try
            {
                hostelRepository.Edit(_hostel, _hostel.id);
                var new_hostel = hostelRepository.GetAll()
                    .FirstOrDefault(h => h.id == _hostel.id);
                if (new_hostel == _hostel)
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
                return new DBResponse<HostelViewModel>
                {
                    Description = $"[GetHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<HostelViewModel> GetHostel(string hostel_name)
        {
            var BaseRes = new DBResponse<HostelViewModel>();
            try
            {
                var hostel = hostelRepository.Get(hostel_name);
                if (hostel != null)
                {
                    BaseRes.Description = "Успешно!";
                    BaseRes.Data = hostel;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<HostelViewModel>
                {
                    Description = $"[GetHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<HostelViewModel>> GetHostels()
        {
            var BaseRes = new DBResponse<IEnumerable<HostelViewModel>>();
            try
            {
                var hostels = hostelRepository.GetAll();
                if (hostels.Count() != 0)
                {
                    BaseRes.Data = hostels;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<HostelViewModel>>
                {
                    Description = $"[GetHostels] : {ex.Message}"
                };
            }
        }
    }
}
