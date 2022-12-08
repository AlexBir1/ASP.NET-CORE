using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IDishesService
    {
        public IBaseResponse<DishesViewModel> CreateDishes(DishesViewModel _Dishes);
        public IBaseResponse<DishesViewModel> EditDishes(DishesViewModel _Dishes);
        public IBaseResponse<DishesViewModel> DeleteDishes(DishesViewModel _Dishes);
        public IBaseResponse<DishesViewModel> GetDishes(string Dishes_name, string cafe_name);
        public IBaseResponse<IEnumerable<DishesViewModel>> GetDishess();
    }
}
