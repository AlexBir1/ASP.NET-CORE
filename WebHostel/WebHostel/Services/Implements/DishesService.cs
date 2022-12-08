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
    public class DishesService : IDishesService
    {
        private readonly DishesRepository DishesRepository;

        public DishesService(DishesRepository _DishesRepository)
        {
            DishesRepository = _DishesRepository;
        }

        public IBaseResponse<DishesViewModel> CreateDishes(DishesViewModel _Dishes)
        {
            var BaseRes = new DBResponse<DishesViewModel>();
            try
            {
                DishesRepository.Create(_Dishes);
                var new_Dishes = DishesRepository.GetAll()
                    .FirstOrDefault(d=>d.title==_Dishes.title && d.cafe_name == _Dishes.cafe_name);
                if (new_Dishes != null)
                {
                    BaseRes.Data = new_Dishes;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<DishesViewModel>
                {
                    Description = $"[CreateDishes] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<DishesViewModel> DeleteDishes(DishesViewModel _Dishes)
        {
            var BaseRes = new DBResponse<DishesViewModel>();
            try
            {
                DishesRepository.Delete(_Dishes);
                var new_Dishes = DishesRepository.GetAll()
                    .FirstOrDefault(d => d.id == _Dishes.id);
                if (new_Dishes == null)
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
                return new DBResponse<DishesViewModel>
                {
                    Description = $"[DeleteDishes] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<DishesViewModel> EditDishes(DishesViewModel _Dishes)
        {
            var BaseRes = new DBResponse<DishesViewModel>();
            try
            {
                DishesRepository.Edit(_Dishes, _Dishes.id);
                var new_hostel = DishesRepository.GetAll()
                    .FirstOrDefault(d => d.id == _Dishes.id);
                if (new_hostel == _Dishes)
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
                return new DBResponse<DishesViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<DishesViewModel> GetDishes(string Dishes_name, string cafe_name)
        {
            var BaseRes = new DBResponse<DishesViewModel>();
            try
            {
                var Dishes = DishesRepository.Get(Dishes_name, cafe_name);
                if (Dishes != null)
                {
                    BaseRes.Data = Dishes;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<DishesViewModel>
                {
                    Description = $"[GetDishes] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<DishesViewModel>> GetDishess()
        {
            var BaseRes = new DBResponse<IEnumerable<DishesViewModel>>();
            try
            {
                var Dishess = DishesRepository.GetAll();
                if (Dishess.Count() != 0)
                {
                    BaseRes.Data = Dishess;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<DishesViewModel>>
                {
                    Description = $"[GetDishess] : {ex.Message}"
                };
            }
        }
    }
}
