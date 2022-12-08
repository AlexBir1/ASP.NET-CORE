using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IServicesService
    {
        public IBaseResponse<ServicesViewModel> CreateServices(ServicesViewModel _Services);
        public IBaseResponse<ServicesViewModel> EditServices(ServicesViewModel _Services);
        public IBaseResponse<ServicesViewModel> DeleteServices(ServicesViewModel _Services);
        public IBaseResponse<ServicesViewModel> GetServices(string Services_name);
        public IBaseResponse<IEnumerable<ServicesViewModel>> GetServicess();
        public IBaseResponse<IEnumerable<ServicesViewModel>> GetServicess(string Services_name);
    }
}
