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
    public class ChosenServicesService : IChosenServicesService
    {
        private readonly Chosen_servicesRepository Chosen_servicesRepository;

        public ChosenServicesService(Chosen_servicesRepository _Chosen_servicesRepository)
        {
            Chosen_servicesRepository = _Chosen_servicesRepository;
        }

        public IBaseResponse<ChosenServicesViewModel> CreateChosenServices(ChosenServicesViewModel _ChosenServices)
        {
            var BaseRes = new DBResponse<ChosenServicesViewModel>();
            try
            {
                Chosen_servicesRepository.Create(_ChosenServices);
                var new_ChosenServices = Chosen_servicesRepository.GetAll()
                    .FirstOrDefault(chs=>chs.customer_num == _ChosenServices.customer_num);
                if (new_ChosenServices != null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "УСЛУГА УСПЕШНО ВЫБРАНА!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА ВЫБОРА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChosenServicesViewModel>
                {
                    Description = $"[CreateChosenServices] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ChosenServicesViewModel> DeleteChosenServices(ChosenServicesViewModel _ChosenServices)
        {
            var BaseRes = new DBResponse<ChosenServicesViewModel>();
            try
            {
                Chosen_servicesRepository.Delete(_ChosenServices);
                var new_ChosenServices = Chosen_servicesRepository.GetAll()
                    .FirstOrDefault(chs=>chs.id==_ChosenServices.id);
                if (new_ChosenServices == null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "УДАЛЕНИЕ УСЛУГИ УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА УДАЛЕНИЯ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChosenServicesViewModel>
                {
                    Description = $"[DeleteChosenServices] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ChosenServicesViewModel> EditChosenServices(ChosenServicesViewModel _ChosenServices)
        {
            var BaseRes = new DBResponse<ChosenServicesViewModel>();
            try
            {
                Chosen_servicesRepository.Edit(_ChosenServices, _ChosenServices.id);
                var new_hostel = Chosen_servicesRepository.GetAll()
                    .FirstOrDefault(chs => chs.id == _ChosenServices.id);
                if (new_hostel == _ChosenServices)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "ИЗМЕНЕНИЕ ДАННЫХ УСЛУГИ УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА ИЗМЕНЕНИЯ ДАННЫХ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChosenServicesViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ChosenServicesViewModel> GetChosenService(string ChosenServices_name)
        {
            var BaseRes = new DBResponse<ChosenServicesViewModel>();
            try
            {
                var ChosenServices = Chosen_servicesRepository.Get(ChosenServices_name);
                if (ChosenServices != null)
                {
                    BaseRes.Data = ChosenServices;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChosenServicesViewModel>
                {
                    Description = $"[GetChosenServices] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<ChosenServicesViewModel>> GetChosenServices()
        {
            var BaseRes = new DBResponse<IEnumerable<ChosenServicesViewModel>>();
            try
            {
                var ChosenServicess = Chosen_servicesRepository.GetAll();
                if (ChosenServicess.Count() != 0)
                {
                    BaseRes.Data = ChosenServicess;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ChosenServicesViewModel>>
                {
                    Description = $"[GetChosenServicess] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<ChosenServicesViewModel> UpdateStatus(ChosenServicesViewModel chosenServices)
        {
            try
            {
                if (Chosen_servicesRepository.UpdateServiceStatus(chosenServices))
                {
                    return new DBResponse<ChosenServicesViewModel>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "Успешно"
                    };
                }
                return new DBResponse<ChosenServicesViewModel>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Онибка"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ChosenServicesViewModel>
                {
                    Description = $"[UpdateServiceStatus] : {ex.Message}"
                };
            }
        }
    }
}
