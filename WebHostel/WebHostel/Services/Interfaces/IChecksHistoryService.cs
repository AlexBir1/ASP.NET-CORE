using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IChecksHistoryService
    {
        public IBaseResponse<Checks_historyViewModel> 
            CreateChecksHistory(Checks_historyViewModel checks_History);

        public IBaseResponse<Checks_historyViewModel> 
            EditChecksHistory(Checks_historyViewModel checks_History);

        public IBaseResponse<Checks_historyViewModel> 
            DeleteChecksHistory(Checks_historyViewModel checks_History);

        public IBaseResponse<IEnumerable<Checks_historyViewModel>> 
            GetChecksHistories(Checks_historyViewModel checks_History);
    }
}
