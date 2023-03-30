using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Interfaces
{
    public interface IUserInterface : IBaseInterface<UserViewModel>
    {
       public ClaimsIdentity AuthenticateUser(UserViewModel User);
        public void GetDataForCUPartials(ref List<UnitViewModel> _locallyCreatedUnitList);
    }
}
