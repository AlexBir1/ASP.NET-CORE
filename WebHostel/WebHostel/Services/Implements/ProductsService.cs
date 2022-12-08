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
    public class ProductsService : IProductsService
    {
        private readonly ProductsRepository ProductsRepository;

        public ProductsService(ProductsRepository _ProductsRepository)
        {
            ProductsRepository = _ProductsRepository;
        }

        public IBaseResponse<ProductsViewModel> CreateProduct(ProductsViewModel product)
        {
            try
            {
                ProductsRepository.Create(product);
                if(ProductsRepository.GetAll().FirstOrDefault(p=>p.title == product.title) != null)
                {
                    return new DBResponse<ProductsViewModel>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<ProductsViewModel>
                {
                    StatusCode = StatusCode.OK,
                    Description = "Успешно!"
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<ProductsViewModel>
                {
                    Description = $"[CreateProduct]: {ex.Message}"
                };
            }
        }

        public IBaseResponse<ProductsViewModel> DeleteProduct(ProductsViewModel product)
        {
            try
            {
                ProductsRepository.Delete(product);
                if (ProductsRepository.GetAll().FirstOrDefault(p => p.id == product.id) == null)
                {
                    return new DBResponse<ProductsViewModel>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<ProductsViewModel>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Ошибка!"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProductsViewModel>
                {
                    Description = $"[DeleteProduct]: {ex.Message}"
                };
            }
        }

        public IBaseResponse<ProductsViewModel> EditProduct(ProductsViewModel product)
        {
            try
            {
                ProductsRepository.Edit(product,product.id);
                if (ProductsRepository.GetAll().FirstOrDefault(p => p.id == product.id) == product)
                {
                    return new DBResponse<ProductsViewModel>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<ProductsViewModel>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Ошибка!"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProductsViewModel>
                {
                    Description = $"[EditProduct]: {ex.Message}"
                };
            }
        }

        public IBaseResponse<ProductsViewModel> GetProduct(ProductsViewModel product)
        {
            try
            {
                var prod = ProductsRepository.GetAll().FirstOrDefault(p=>p.title == product.title);
                if (prod != null)
                {
                    return new DBResponse<ProductsViewModel>
                    {
                        Data = prod,
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<ProductsViewModel>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Ошибка!"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ProductsViewModel>
                {
                    Description = $"[GetProduct]: {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<ProductsViewModel>> GetProducts()
        {
            try
            {
                var prod = ProductsRepository.GetAll();
                if (prod.Count() != 0)
                {
                    return new DBResponse<IEnumerable<ProductsViewModel>>
                    {
                        Data = prod,
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<IEnumerable<ProductsViewModel>>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Ошибка!"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ProductsViewModel>>
                {
                    Description = $"[GetProducts]: {ex.Message}"
                };
            }
        }
    }
}
