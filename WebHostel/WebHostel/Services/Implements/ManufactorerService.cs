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
    public class ManufactorerService : IManufactorerService
    {
        private readonly ManufactorerRepository manufactorerRepository;

        public ManufactorerService(ManufactorerRepository _ManufactorerRepository)
        {
            manufactorerRepository = _ManufactorerRepository;
        }

        public IBaseResponse<ManufactorerViewModel> CreateManufactorer(ManufactorerViewModel manufactorer)
        {
            try
            {
                manufactorerRepository.Create(manufactorer);
                if (manufactorerRepository.GetAll()
                    .FirstOrDefault(m=>m.phone == manufactorer.phone) != null)
                {
                    return new DBResponse<ManufactorerViewModel>
                    {
                        Description = "Inserted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<ManufactorerViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<ManufactorerViewModel>
                {
                    Description = $"[CreateManufactorer] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ManufactorerViewModel> DeleteManufactorer(ManufactorerViewModel manufactorer)
        {
            try
            {
                manufactorerRepository.Delete(manufactorer);
                if (manufactorerRepository.GetAll()
                    .FirstOrDefault(m => m.id == manufactorer.id) == null)
                {
                    return new DBResponse<ManufactorerViewModel>
                    {
                        Description = "deleted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<ManufactorerViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ManufactorerViewModel>
                {
                    Description = $"[DeleteManufactorer] : {ex.Message}",
                    StatusCode = StatusCode.OK
                };
            }
        }

        public IBaseResponse<ManufactorerViewModel> EditManufactorer(ManufactorerViewModel manufactorer)
        {
            try
            {
                manufactorerRepository.Edit(manufactorer, manufactorer.id);
                if (manufactorerRepository.GetAll()
                    .FirstOrDefault(m => m.id == manufactorer.id) == manufactorer)
                {
                    return new DBResponse<ManufactorerViewModel>
                    {
                        Description = "deleted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<ManufactorerViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ManufactorerViewModel>
                {
                    Description = $"[EditManufactorer] : {ex.Message}",
                    StatusCode = StatusCode.OK
                };
            }
        }

        public IBaseResponse<IEnumerable<ManufactorerViewModel>> GetManufactorers()
        {
            try
            {

                var manufactorers = manufactorerRepository.GetAll();
                if (manufactorers.Count() != 0)
                {
                    return new DBResponse<IEnumerable<ManufactorerViewModel>>
                    {
                        Data = manufactorers,
                        Description = "found",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<ManufactorerViewModel>>
                {
                    Description = "not found any",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<ManufactorerViewModel>>
                {
                    Description = $"[GetManufactorers] : {ex.Message}",
                    StatusCode = StatusCode.OK
                };
            }
        }
    }
}
