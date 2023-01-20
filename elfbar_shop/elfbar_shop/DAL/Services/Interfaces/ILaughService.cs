using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface ILaughService
    {
        public IBaseResponse<LaughViewModel> CreateL(LaughViewModel laugh);
        public IBaseResponse<LaughViewModel> DeleteL(LaughViewModel laugh);
        public IBaseResponse<LaughPageViewModel> GetLs();
    }
}
