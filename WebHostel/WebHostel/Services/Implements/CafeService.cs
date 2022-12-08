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
    public class CafeService : ICafeService
    {
        private readonly CafeRepository CafeRepository;

        public CafeService(CafeRepository _CafeRepository)
        {
            CafeRepository = _CafeRepository;
        }

        public IBaseResponse<CafeViewModel> CreateCafe(CafeViewModel _Cafe)
        {
            var BaseRes = new DBResponse<CafeViewModel>();
            try
            {
                CafeRepository.Create(_Cafe);
                var new_Cafe = CafeRepository.GetAll()
                    .FirstOrDefault(c => c.title == _Cafe.title);
                if (new_Cafe != null)
                {
                    BaseRes.Data = new_Cafe;
                    BaseRes.Description = "СОЗДАНИЕ КАФЕ УСПЕШНО!";
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА СОЗДАНИЯ КАФЕ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CafeViewModel>
                {
                    Description = $"[CreateCafe] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CafeViewModel> DeleteCafe(CafeViewModel _Cafe)
        {
            var BaseRes = new DBResponse<CafeViewModel>();
            try
            {
                CafeRepository.Delete(_Cafe);
                var new_Cafe = CafeRepository.GetAll()
                    .FirstOrDefault(c => c.title == _Cafe.title);
                if (new_Cafe == null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "УДАЛЕНИЕ КАФЕ УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА УДАЛЕНИЯ КАФЕ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CafeViewModel>
                {
                    Description = $"[DeleteCafe] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CafeViewModel> EditCafe(CafeViewModel _Cafe)
        {
            var BaseRes = new DBResponse<CafeViewModel>();
            try
            {
                CafeRepository.Edit(_Cafe, _Cafe.id);
                var new_hostel = CafeRepository.GetAll()
                    .FirstOrDefault(c => c.id == _Cafe.id);
                if (new_hostel == _Cafe)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "ИЗМЕНЕНИЕ КАФЕ УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА ИЗМЕНЕНИЯ КАФЕ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CafeViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CafeViewModel> GetCafe(string Cafe_name)
        {
            var BaseRes = new DBResponse<CafeViewModel>();
            try
            {
                var Cafe = CafeRepository.Get(Cafe_name);
                if (Cafe != null)
                {
                    BaseRes.Data = Cafe;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CafeViewModel>
                {
                    Description = $"[GetCafe] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<CafeViewModel>> GetCafes()
        {
            var BaseRes = new DBResponse<IEnumerable<CafeViewModel>>();
            try
            {
                var Cafes = CafeRepository.GetAll();
                if (Cafes.Count() != 0)
                {
                    BaseRes.Data = Cafes;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<CafeViewModel>>
                {
                    Description = $"[GetCafes] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<IEnumerable<CafeViewModel>> GetCafes(string hostel_name)
        {
            var BaseRes = new DBResponse<IEnumerable<CafeViewModel>>();
            try
            {
                var Cafes = CafeRepository.GetAll(hostel_name);
                if (Cafes.Count() != 0)
                {
                    BaseRes.Data = Cafes;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<CafeViewModel>>
                {
                    Description = $"[GetCafes] : {ex.Message}"
                };
            }
        }
    }
}
