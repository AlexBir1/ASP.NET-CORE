using elfbar_shop.Domain.Response;
using elfbar_shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elfbar_shop.DAL.Services.Interfaces
{
    public interface IProductService
    {
        public IBaseResponse<ProductViewModel> CreateProduct(ProductViewModel _product);
        public IBaseResponse<ProductViewModel> DeleteProduct(ProductViewModel _product);
        public IBaseResponse<ProductViewModel> EditProduct(ProductViewModel _product);
        public Task<IBaseResponse<ProductPageViewModel>> GetProducts();
    }
}
