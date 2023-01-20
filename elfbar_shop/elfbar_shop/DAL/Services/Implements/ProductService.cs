using elfbar_shop.Domain.Entities;
using elfbar_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using elfbar_shop.DAL.Services.Interfaces;
using elfbar_shop.Domain.Response;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace elfbar_shop.DAL.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext dbase;

        public ProductService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<ProductViewModel> CreateProduct(ProductViewModel _product)
        {
            try
            {
                var Type = dbase.Types.Where(t => t.title == _product.type_name).FirstOrDefault();
                var Product = new Product
                {
                    id = _product.id,
                    title = _product.title,
                    quantity = _product.quantity,
                    cost = _product.cost,
                    types_id = Type.id
                };
                if(dbase.Product.Where(p=>p.title.ToLower() == _product.title.ToLower() && p.types_id == Type.id).FirstOrDefault() == null)
                {
                    dbase.Product.Add(Product);
                    dbase.SaveChanges();
                    return new DBResponse<ProductViewModel>
                    {
                        Description = "SUCCESS",
                        StatusCode = StatusCodes.OK
                    };
                }
                return new DBResponse<ProductViewModel>
                {
                    Description = "Error: таке уже є в базі",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<ProductViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<ProductViewModel> DeleteProduct(ProductViewModel _product)
        {
            try
            {
                var Type = dbase.Types.Where(t => t.title == _product.type_name).FirstOrDefault();
                var Product = new Product
                {
                    id = _product.id,
                    title = _product.title,
                    quantity = _product.quantity,
                    cost = _product.cost,
                    types_id = Type.id
                };

                dbase.Product.Remove(Product);
                dbase.SaveChanges();

                if (dbase.Product.Where(p => p.id == _product.id).FirstOrDefault() == null)
                    return new DBResponse<ProductViewModel>
                    {
                        Description = "SUCCESS",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<ProductViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProductViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<ProductViewModel> EditProduct(ProductViewModel _product)
        {
            try
            {
                var Type = dbase.Types.Where(t => t.title == _product.type_name).FirstOrDefault();
                var Product = new Product
                {
                    id = _product.id,
                    title = _product.title,
                    quantity = _product.quantity,
                    cost = _product.cost,
                    types_id = Type.id
                };

                dbase.Update(Product);
                dbase.SaveChanges();

                if (dbase.Product.Where(p => p.id == _product.id).FirstOrDefault().id == _product.id)
                    return new DBResponse<ProductViewModel>
                    {
                        Description = "SUCCESS",
                        StatusCode = StatusCodes.OK,
                        Data = _product
                       
                    };
                return new DBResponse<ProductViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProductViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public async Task <IBaseResponse<ProductPageViewModel>> GetProducts()
        {
            try
            {
                var products = await (from p in dbase.Product
                                join t in dbase.Types
                                on p.types_id equals t.id
                                select new ProductViewModel
                                {
                                    id = p.id,
                                    title = p.title,
                                    quantity = p.quantity,
                                    cost = p.cost,
                                    type_name = t.title
                                }).ToListAsync();

                var _types = await (from t in dbase.Types
                              select new SelectListItem
                              {
                                  Text = t.title,
                                  Value = t.title
                              }).ToListAsync();

                dbase.Dispose();
                if (products.Count != 0)
                    return new DBResponse<ProductPageViewModel>
                    {
                        Data = new ProductPageViewModel 
                        {
                            ProductList = products, 
                            ProdTypes = _types
                        },
                        Description = "SUCCESS",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<ProductPageViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.DataIsEmpty
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProductPageViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }
    }
}
