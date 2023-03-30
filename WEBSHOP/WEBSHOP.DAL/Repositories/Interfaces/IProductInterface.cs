using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Interfaces
{
    public interface IProductInterface : IBaseInterface<ProductViewModel>
    {
        public Task<IEnumerable<ProductViewModel>> GetAllByType(int type_id);
        public Task<IEnumerable<ProductViewModel>> GetAllByOrderId(int OrderId);
        public void GetDataForCU(ref List<TypesViewModel> _locallyCreatedTypeList, ref List<UnitViewModel> __locallyCreatedUnitList, ref List<ManufactorerViewModel> _locallyCreatedMnfList);

    }
}
