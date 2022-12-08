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
    public class CarsService : ICarsService
    {
        private readonly CarsRepository CarsRepository;

        public CarsService(CarsRepository _CarsRepository)
        {
            CarsRepository = _CarsRepository;
        }

        public IBaseResponse<CarsViewModel> CreateCars(CarsViewModel _Cars)
        {
            var BaseRes = new DBResponse<CarsViewModel>();
            try
            {
                CarsRepository.Create(_Cars);
                var new_Car = CarsRepository.Get(_Cars.num);
                if (new_Car != null)
                {
                    BaseRes.Data = new_Car;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CarsViewModel>
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CarsViewModel> DeleteCars(CarsViewModel _Cars)
        {
            var BaseRes = new DBResponse<CarsViewModel>();
            try
            {
                CarsRepository.Delete(_Cars);
                var new_Cars = CarsRepository.Get(_Cars.num);
                if (new_Cars == null)
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
                return new DBResponse<CarsViewModel>
                {
                    Description = $"[DeleteCars] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CarsViewModel> EditCars(CarsViewModel _Cars)
        {
            var BaseRes = new DBResponse<CarsViewModel>();
            try
            {
                CarsRepository.Edit(_Cars, _Cars.id);
                var new_hostel = CarsRepository.Get(_Cars.num);
                if (new_hostel == _Cars)
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
                return new DBResponse<CarsViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CarsViewModel> GetCars(string Cars_name)
        {
            var BaseRes = new DBResponse<CarsViewModel>();
            try
            {
                var Cars = CarsRepository.Get(Cars_name);
                if (Cars != null)
                {
                    BaseRes.Data = Cars;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CarsViewModel>
                {
                    Description = $"[GetCars] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<CarsViewModel>> GetCarss()
        {
            var BaseRes = new DBResponse<IEnumerable<CarsViewModel>>();
            try
            {
                var Carss = CarsRepository.GetAll();
                if (Carss.Count() != 0)
                {
                    BaseRes.Data = Carss;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<CarsViewModel>>
                {
                    Description = $"[GetCarss] : {ex.Message}"
                };
            }
        }
    }
}
