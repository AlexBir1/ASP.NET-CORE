using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IWordersService
    {
        public IBaseResponse<wordersViewModel> 
            CreateWOrder(wordersViewModel _worder);
        public IBaseResponse<wordersViewModel>
            DeleteWOrder(wordersViewModel _worder);
        public IBaseResponse<wordersViewModel>
            EditWOrder(wordersViewModel _worder);
        public IBaseResponse<IEnumerable<wordersViewModel>>
            GetWOrders();
    }
}
