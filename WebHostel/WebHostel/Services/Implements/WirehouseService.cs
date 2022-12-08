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
    public class WirehouseService : IWirehouseService
    {
        private readonly WirehouseRepository wirehouseRepository;

        public WirehouseService(WirehouseRepository _wirehouseRepository)
        {
            wirehouseRepository = _wirehouseRepository;
        }

        public IBaseResponse<WirehouseViewModel> 
            CreateWirehouse(WirehouseViewModel _wirehouse)
        {
            try
            {
                wirehouseRepository.Create(_wirehouse);
                if (wirehouseRepository.GetAll()
                    .FirstOrDefault(wr=>wr.title == _wirehouse.title) != null)
                {
                    return new DBResponse<WirehouseViewModel>
                    {
                        Description = "inserted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<WirehouseViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<WirehouseViewModel>
                {
                    Description = $"[CreateWirehouse] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<WirehouseViewModel> 
            DeleteWirehouse(WirehouseViewModel _wirehouse)
        {
            try
            {
                wirehouseRepository.Delete(_wirehouse);
                if (wirehouseRepository.GetAll()
                    .FirstOrDefault(wr => wr.id == _wirehouse.id) == null)
                {
                    return new DBResponse<WirehouseViewModel>
                    {
                        Description = "deleted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<WirehouseViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<WirehouseViewModel>
                {
                    Description = $"[DeleteWirehouse] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<WirehouseViewModel> 
            EditWirehouse(WirehouseViewModel _wirehouse)
        {
            try
            {
                wirehouseRepository.Edit(_wirehouse, _wirehouse.id);
                if (wirehouseRepository.GetAll()
                    .FirstOrDefault(wr => wr.id == _wirehouse.id) == _wirehouse)
                {
                    return new DBResponse<WirehouseViewModel>
                    {
                        Description = "edited",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<WirehouseViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<WirehouseViewModel>
                {
                    Description = $"[EditWirehouse] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<WirehouseViewModel>> GetWirehouses()
        {
            try
            {
                var wirehouses = wirehouseRepository.GetAll();
                if (wirehouses.Count() != 0)
                {
                    return new DBResponse<IEnumerable<WirehouseViewModel>>
                    {
                        Data = wirehouses,
                        Description = "found",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<WirehouseViewModel>>
                {
                    Description = "not found any",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<WirehouseViewModel>>
                {
                    Description = $"[GetWirehouses] : {ex.Message}"
                };
            }
        }
    }
}
