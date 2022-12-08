using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IOrderedProductsService
    {
        public IBaseResponse<ordered_productsViewModel> 
            CreateOProduct(ordered_productsViewModel ordered_Product);

        public IBaseResponse<ordered_productsViewModel> 
            DeleteOProduct(ordered_productsViewModel ordered_Product);

        public IBaseResponse<ordered_productsViewModel> 
            EditOProduct(ordered_productsViewModel ordered_Product);

        public IBaseResponse<IEnumerable<ordered_productsViewModel>> GetOProducts();
    }
}
