using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IChecksService
    {
        public IBaseResponse<ChecksViewModel> CreateChecks(ChecksViewModel _Checks);
        public IBaseResponse<ChecksViewModel> EditChecks(ChecksViewModel _Checks);
        public IBaseResponse<ChecksViewModel> DeleteChecks(ChecksViewModel _Checks);
        public IBaseResponse<ChecksViewModel> GetChecks(string room_num);
        public IBaseResponse<IEnumerable<ChecksViewModel>> GetCheckss();
    }
}
