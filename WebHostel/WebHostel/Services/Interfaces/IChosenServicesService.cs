using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IChosenServicesService
    {
        public IBaseResponse<ChosenServicesViewModel> CreateChosenServices(ChosenServicesViewModel _ChosenServices);
        public IBaseResponse<ChosenServicesViewModel> EditChosenServices(ChosenServicesViewModel _ChosenServices);
        public IBaseResponse<ChosenServicesViewModel> DeleteChosenServices(ChosenServicesViewModel _ChosenServices);
        public IBaseResponse<ChosenServicesViewModel> GetChosenService(string ChosenServices_name);
        public IBaseResponse<IEnumerable<ChosenServicesViewModel>> GetChosenServices();
    }
}
