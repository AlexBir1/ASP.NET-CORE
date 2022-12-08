using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IServices_historyService
    {
        public IBaseResponse<Services_historyViewModel> CreateServices_history(Services_historyViewModel _Services_history);
        public IBaseResponse<Services_historyViewModel> EditServices_history(Services_historyViewModel _Services_history);
        public IBaseResponse<Services_historyViewModel> DeleteServices_history(Services_historyViewModel _Services_history);
        public IBaseResponse<Services_historyViewModel> GetServices_history(string Services_history_name);
        public IBaseResponse<IEnumerable<Services_historyViewModel>> GetServices_historys();
        public IBaseResponse<IEnumerable<Services_historyViewModel>> GetServices_historys(string Services_history_name);
    }
}
