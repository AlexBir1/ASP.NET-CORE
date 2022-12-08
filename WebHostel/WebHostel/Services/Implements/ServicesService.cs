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
    public class ServicesService : IServicesService
    {
        private readonly ServicesRepository ServicesRepository;

        public ServicesService(ServicesRepository _ServicesRepository)
        {
            ServicesRepository = _ServicesRepository;
        }

        public IBaseResponse<ServicesViewModel> CreateServices(ServicesViewModel _Services)
        {
            var BaseRes = new DBResponse<ServicesViewModel>();
            try
            {
                ServicesRepository.Create(_Services);
                var new_Services = ServicesRepository.Get(_Services.title, _Services.hostel_name);
                if (new_Services != null)
                {
                    BaseRes.Data = new_Services;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ServicesViewModel>
                {
                    Description = $"[CreateServices] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ServicesViewModel> DeleteServices(ServicesViewModel _Services)
        {
            var BaseRes = new DBResponse<ServicesViewModel>();
            try
            {
                ServicesRepository.Delete(_Services);
                var new_Services = ServicesRepository.Get(_Services.title, _Services.hostel_name);
                if (new_Services == null)
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
                return new DBResponse<ServicesViewModel>
                {
                    Description = $"[DeleteServices] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ServicesViewModel> EditServices(ServicesViewModel _Services)
        {
            var BaseRes = new DBResponse<ServicesViewModel>();
            try
            {
                ServicesRepository.Edit(_Services, _Services.id);
                var new_hostel = ServicesRepository.Get(_Services.title, _Services.hostel_name);
                if (new_hostel == _Services)
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
                return new DBResponse<ServicesViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ServicesViewModel> GetServices(string Services_name)
        {
            var BaseRes = new DBResponse<ServicesViewModel>();
            try
            {
                var Services = ServicesRepository.Get(Services_name);
                if (Services != null)
                {
                    BaseRes.Data = Services;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ServicesViewModel>
                {
                    Description = $"[GetServices] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<ServicesViewModel>> GetServicess()
        {
            var BaseRes = new DBResponse<IEnumerable<ServicesViewModel>>();
            try
            {
                var Servicess = ServicesRepository.GetAll();
                if (Servicess.Count() != 0)
                {
                    BaseRes.Data = Servicess;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ServicesViewModel>>
                {
                    Description = $"[GetServicess] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<ServicesViewModel>> GetServicess(string Services_name)
        {
            var BaseRes = new DBResponse<IEnumerable<ServicesViewModel>>();
            try
            {
                var Servicess = ServicesRepository.GetAll().Where(S=>S.hostel_name == Services_name);
                if (Servicess.Count() != 0)
                {
                    BaseRes.Data = Servicess;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ServicesViewModel>>
                {
                    Description = $"[GetServicess] : {ex.Message}"
                };
            }
        }
    }
}
