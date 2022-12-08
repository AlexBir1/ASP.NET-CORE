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
    public class Services_historyService : IServices_historyService
    {
        private readonly Services_historyRepository Services_historyRepository;

        public Services_historyService(Services_historyRepository _Services_historyRepository)
        {
            Services_historyRepository = _Services_historyRepository;
        }

        public IBaseResponse<Services_historyViewModel> CreateServices_history(Services_historyViewModel _Services_history)
        {
            var BaseRes = new DBResponse<Services_historyViewModel>();
            try
            {
                Services_historyRepository.Create(_Services_history);
                var new_Services_history = Services_historyRepository.GetAll()
                    .FirstOrDefault(sh=>sh.stitle == _Services_history.stitle 
                    && sh.customer_num == _Services_history.customer_num);
                if (new_Services_history != null)
                {
                    BaseRes.Data = new_Services_history;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<Services_historyViewModel>
                {
                    Description = $"[CreateServices_history] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Services_historyViewModel> DeleteServices_history(Services_historyViewModel _Services_history)
        {
            var BaseRes = new DBResponse<Services_historyViewModel>();
            try
            {
                Services_historyRepository.Delete(_Services_history);
                var new_Services_history = Services_historyRepository.GetAll()
                    .FirstOrDefault(sh => sh.id == _Services_history.id);
                if (new_Services_history == null)
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
                return new DBResponse<Services_historyViewModel>
                {
                    Description = $"[DeleteServices_history] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Services_historyViewModel> EditServices_history(Services_historyViewModel _Services_history)
        {
            var BaseRes = new DBResponse<Services_historyViewModel>();
            try
            {
                Services_historyRepository.Edit(_Services_history, _Services_history.id);
                var new_hostel = Services_historyRepository.GetAll()
                    .FirstOrDefault(sh => sh.id == _Services_history.id);
                if (new_hostel == _Services_history)
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
                return new DBResponse<Services_historyViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Services_historyViewModel> GetServices_history(string Services_history_name)
        {
            var BaseRes = new DBResponse<Services_historyViewModel>();
            try
            {
                var Services_history = Services_historyRepository.Get(Services_history_name);
                if (Services_history != null)
                {
                    BaseRes.Data = Services_history;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<Services_historyViewModel>
                {
                    Description = $"[GetServices_history] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<Services_historyViewModel>> GetServices_historys()
        {
            var BaseRes = new DBResponse<IEnumerable<Services_historyViewModel>>();
            try
            {
                var Services_historyRepositorys = Services_historyRepository.GetAll();
                if (Services_historyRepositorys.Count() != 0)
                {
                    BaseRes.Data = Services_historyRepositorys;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Services_historyViewModel>>
                {
                    Description = $"[GetServices_historys] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<Services_historyViewModel>> GetServices_historys(string Services_history_name)
        {
            throw new NotImplementedException();
        }
    }
}
