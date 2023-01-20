using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface ISell_InfoService
    {
        public IBaseResponse<Sell_InfoViewModel> CreateSell_info(Sell_InfoViewModel sell_Info);
        public IBaseResponse<Sell_InfoViewModel> DeleteSell_info(Sell_InfoViewModel sell_Info);
        public IBaseResponse<Sell_InfoViewModel> EditSell_info(Sell_InfoViewModel sell_Info);
        public IBaseResponse<Sell_InfoViewModel> GetSell_info();
        public IBaseResponse<Sell_InfoViewModel> SetRBalance();
    }
}
