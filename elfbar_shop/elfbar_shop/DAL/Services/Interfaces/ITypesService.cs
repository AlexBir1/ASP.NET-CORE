using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface ITypesService
    {
        public IBaseResponse<TypesViewModel> CreateType(TypesViewModel _type);
        public IBaseResponse<TypesViewModel> DeleteType(TypesViewModel _type);
        public IBaseResponse<TypesViewModel> EditType(TypesViewModel _type);
        public Task<IBaseResponse<TypesPageViewModel>> GetTypes();
    }
}
