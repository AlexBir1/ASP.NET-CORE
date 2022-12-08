using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IHostelService
    {
        public IBaseResponse<HostelViewModel> CreateHostel(HostelViewModel _hostel);
        public IBaseResponse<HostelViewModel> EditHostel(HostelViewModel _hostel);
        public IBaseResponse<HostelViewModel> DeleteHostel(HostelViewModel _hostel);
        public IBaseResponse<HostelViewModel> GetHostel(string hostel_name);
        public IBaseResponse<IEnumerable<HostelViewModel>> GetHostels();
    }
}
