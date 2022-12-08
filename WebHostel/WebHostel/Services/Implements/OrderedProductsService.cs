using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Implements
{
    public class OrderedProductsService : IOrderedProductsService
    {
        private readonly OrderedProductsRepository orderedProducts;

        public OrderedProductsService(OrderedProductsRepository _orderedProducts)
        {
            orderedProducts = _orderedProducts;
        }

        public IBaseResponse<ordered_productsViewModel> 
            CreateOProduct(ordered_productsViewModel ordered_Product)
        {
            try
            {
                orderedProducts.Create(ordered_Product);
                if (orderedProducts.GetAll().FirstOrDefault(op=>op.title == ordered_Product.title
                && op.hostel_name == ordered_Product.hostel_name) != null)
                {
                    return new DBResponse<ordered_productsViewModel>
                    {
                        Description = "inserted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<ordered_productsViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<ordered_productsViewModel>
                {
                    Description = $"[CreateOProduct] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ordered_productsViewModel> 
            DeleteOProduct(ordered_productsViewModel ordered_Product)
        {
            try
            {
                orderedProducts.Delete(ordered_Product);
                if (orderedProducts.GetAll()
                    .FirstOrDefault(op => op.id == ordered_Product.id) == null)
                {
                    return new DBResponse<ordered_productsViewModel>
                    {
                        Description = "deleted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<ordered_productsViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ordered_productsViewModel>
                {
                    Description = $"[DeleteOProduct] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ordered_productsViewModel> 
            EditOProduct(ordered_productsViewModel ordered_Product)
        {
            try
            {
                orderedProducts.Edit(ordered_Product, ordered_Product.id);
                if (orderedProducts.GetAll()
                    .FirstOrDefault(op => op.id == ordered_Product.id) == ordered_Product)
                {
                    return new DBResponse<ordered_productsViewModel>
                    {
                        Description = "edited",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<ordered_productsViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ordered_productsViewModel>
                {
                    Description = $"[EditOProduct] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<ordered_productsViewModel>> GetOProducts()
        {
            try
            {
                var oProducts = orderedProducts.GetAll();
                if (oProducts.Count() != 0)
                {
                    return new DBResponse<IEnumerable<ordered_productsViewModel>>
                    {
                        Data = oProducts,
                        Description = "found",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<ordered_productsViewModel>>
                {
                    Description = "not found any",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ordered_productsViewModel>>
                {
                    Description = $"[GetOProducts] : {ex.Message}"
                };
            }
        }
    }
}
