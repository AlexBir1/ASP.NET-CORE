using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface ICarsService
    {
        public IBaseResponse<CarsViewModel> CreateCars(CarsViewModel _Cars);
        public IBaseResponse<CarsViewModel> EditCars(CarsViewModel _Cars);
        public IBaseResponse<CarsViewModel> DeleteCars(CarsViewModel _Cars);
        public IBaseResponse<CarsViewModel> GetCars(string Cars_name);
        public IBaseResponse<IEnumerable<CarsViewModel>> GetCarss();
    }
}
