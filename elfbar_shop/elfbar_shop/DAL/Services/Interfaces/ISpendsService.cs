using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface ISpendsService
    {
        public IBaseResponse<SpendsViewModel> CreateSpend(SpendsViewModel _spend);
        public IBaseResponse<SpendsViewModel> DeleteSpend(SpendsViewModel _spend);
        public IBaseResponse<SpendsViewModel> EditSpend(SpendsViewModel _spend);
        public Task<IBaseResponse<SpendsPageViewModel>> GetSpends();
    }
}
