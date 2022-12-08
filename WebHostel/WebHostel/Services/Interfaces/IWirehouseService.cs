using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IWirehouseService
    {
        public IBaseResponse<WirehouseViewModel> 
            CreateWirehouse(WirehouseViewModel _wirehouse);

        public IBaseResponse<WirehouseViewModel>
            DeleteWirehouse(WirehouseViewModel _wirehouse);

        public IBaseResponse<WirehouseViewModel>
            EditWirehouse(WirehouseViewModel _wirehouse);

        public IBaseResponse<IEnumerable<WirehouseViewModel>>
            GetWirehouses();
    }
}
