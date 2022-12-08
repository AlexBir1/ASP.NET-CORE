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
    public class ChecksService : IChecksService
    {
        private readonly ChecksRepository ChecksRepository;

        public ChecksService(ChecksRepository _ChecksRepository)
        {
            ChecksRepository = _ChecksRepository;
        }

        public IBaseResponse<ChecksViewModel> CreateChecks(ChecksViewModel _Checks)
        {
            var BaseRes = new DBResponse<ChecksViewModel>();
            try
            {
                ChecksRepository.Create(_Checks);
                var new_Checks = ChecksRepository.GetAll()
                    .FirstOrDefault(ch => ch.customer_num == _Checks.customer_num);
                if (new_Checks != null)
                {
                    BaseRes.Data = new_Checks;
                    BaseRes.Description = "ЗАСЕЛЕНИЕ УСПЕШНО!";
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА ЗАСЕЛЕНИЯ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChecksViewModel>
                {
                    Description = $"[CreateChecks] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ChecksViewModel> DeleteChecks(ChecksViewModel _Checks)
        {
            var BaseRes = new DBResponse<ChecksViewModel>();
            try
            {
                ChecksRepository.Delete(_Checks);
                var new_Checks = ChecksRepository.GetAll()
                    .FirstOrDefault(ch=>ch.id==_Checks.id);
                if (new_Checks == null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChecksViewModel>
                {
                    Description = $"[DeleteChecks] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ChecksViewModel> EditChecks(ChecksViewModel _Checks)
        {
            var BaseRes = new DBResponse<ChecksViewModel>();
            try
            {
                ChecksRepository.Edit(_Checks, _Checks.id);
                var new_Checks = ChecksRepository.GetAll()
                    .FirstOrDefault(ch => ch.id == _Checks.id);
                if (new_Checks == _Checks)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "ИЗМЕНЕНИЕ ДАННЫХ О ЗАЕЗДЕ УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА ИЗМЕНЕНИЯ ДАННЫХ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChecksViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ChecksViewModel> GetChecks(string room_num)
        {
            var BaseRes = new DBResponse<ChecksViewModel>();
            try
            {
                var Checks = ChecksRepository.Get(room_num);
                if (Checks != null)
                {
                    BaseRes.Data = Checks;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<ChecksViewModel>
                {
                    Description = $"[GetChecks] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<ChecksViewModel>> GetCheckss()
        {
            var BaseRes = new DBResponse<IEnumerable<ChecksViewModel>>();
            try
            {
                var Checkss = ChecksRepository.GetAll();
                if (Checkss.Count() != 0)
                {
                    BaseRes.Data = Checkss;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ChecksViewModel>>
                {
                    Description = $"[GetCheckss] : {ex.Message}"
                };
            }
        }

    }
}
