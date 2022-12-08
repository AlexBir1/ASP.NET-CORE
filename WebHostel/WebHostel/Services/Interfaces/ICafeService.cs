using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface ICafeService
    {
        public IBaseResponse<CafeViewModel> CreateCafe(CafeViewModel _Cafe);
        public IBaseResponse<CafeViewModel> EditCafe(CafeViewModel _Cafe);
        public IBaseResponse<CafeViewModel> DeleteCafe(CafeViewModel _Cafe);
        public IBaseResponse<CafeViewModel> GetCafe(string Cafe_name);
        public IBaseResponse<IEnumerable<CafeViewModel>> GetCafes();
        public IBaseResponse<IEnumerable<CafeViewModel>> GetCafes(string cafe_name);
    }
}
