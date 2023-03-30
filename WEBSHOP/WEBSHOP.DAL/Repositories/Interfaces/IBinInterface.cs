using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Interfaces
{
    public interface IBinInterface : IBaseInterface<BinViewModel>
    {
        public Task<IEnumerable<BinViewModel>> GetByUserId(int Id);
        public bool DeleteAllByUserId(int UserId);
    }
}
