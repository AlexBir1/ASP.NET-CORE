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
    public class WordersService : IWordersService
    {
        private readonly WordersRepository wordersRepository;

        public WordersService(WordersRepository _wordersRepository)
        {
            wordersRepository = _wordersRepository;
        }

        public IBaseResponse<wordersViewModel> 
            CreateWOrder(wordersViewModel _worder)
        {
            try
            {
                wordersRepository.Create(_worder);
                if (wordersRepository.GetAll()
                    .FirstOrDefault(wo => wo.title == _worder.title
                && wo.wirehouse_name == _worder.wirehouse_name
                && wo.employee_num == _worder.employee_num) != null)
                {
                    return new DBResponse<wordersViewModel>
                    {
                        Description = "inserted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<wordersViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<wordersViewModel>
                {
                    Description = $"[CreateWOrder] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<wordersViewModel> 
            DeleteWOrder(wordersViewModel _worder)
        {
            try
            {
                wordersRepository.Delete(_worder);
                if (wordersRepository.GetAll()
                    .FirstOrDefault(wo => wo.id == _worder.id) == null)
                {
                    return new DBResponse<wordersViewModel>
                    {
                        Description = "inserted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<wordersViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<wordersViewModel>
                {
                    Description = $"[DeleteWOrder] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<wordersViewModel> 
            EditWOrder(wordersViewModel _worder)
        {
            try
            {
                wordersRepository.Edit(_worder, _worder.id);
                if (wordersRepository.GetAll()
                    .FirstOrDefault(wo => wo.id == _worder.id) == _worder)
                {
                    return new DBResponse<wordersViewModel>
                    {
                        Description = "edited",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<wordersViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<wordersViewModel>
                {
                    Description = $"[EditWOrder] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<wordersViewModel>> GetWOrders()
        {
            try
            {
                var worders = wordersRepository.GetAll();
                if (worders.Count() != 0)
                {
                    return new DBResponse<IEnumerable<wordersViewModel>>
                    {
                        Data = worders,
                        Description = "found",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<wordersViewModel>>
                {
                    Description = "not found any",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<wordersViewModel>>
                {
                    Description = $"[GetWOrders] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<wordersViewModel> UpdateOrderWStatus(wordersViewModel worder)
        {
            try
            {
                if (wordersRepository.UpdateStatusWOrder(worder))
                {
                    return new DBResponse<wordersViewModel>
                    {
                        StatusCode = StatusCode.OK,
                        Description = "Успешно!"
                    };
                }
                return new DBResponse<wordersViewModel>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = "Ошибка!"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<wordersViewModel>
                {
                    Description = $"[UpdateStatusWOrder]: {ex.Message}"
                };
            }
        }
    }
}
