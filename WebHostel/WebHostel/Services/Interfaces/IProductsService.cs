using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Interfaces
{
    public interface IProductsService
    {
        public IBaseResponse<ProductsViewModel> CreateProduct(ProductsViewModel product);
        public IBaseResponse<ProductsViewModel> EditProduct(ProductsViewModel product);
        public IBaseResponse<ProductsViewModel> DeleteProduct(ProductsViewModel product);
        public IBaseResponse<ProductsViewModel> GetProduct(ProductsViewModel product);
        public IBaseResponse<IEnumerable<ProductsViewModel>> GetProducts();
    }
}
