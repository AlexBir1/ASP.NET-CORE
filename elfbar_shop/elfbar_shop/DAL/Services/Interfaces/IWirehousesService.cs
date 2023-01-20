using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface IWirehousesService
    {
        public IBaseResponse<WirehousesViewModel> CreateW(WirehousesViewModel w);
        public IBaseResponse<WirehousesViewModel> DeleteW(WirehousesViewModel w);
        public IBaseResponse<WirehousesViewModel> EditW(WirehousesViewModel w);
        public Task<IBaseResponse<WirehousesPageViewModel>> GetWs();
    }
}
