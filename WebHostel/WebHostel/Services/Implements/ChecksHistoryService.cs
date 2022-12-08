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
    public class ChecksHistoryService : IChecksHistoryService
    {
        private readonly ChecksHistoryRepository ChecksHistoryRepository;

        public ChecksHistoryService(ChecksHistoryRepository _ChecksHistoryRepository)
        {
            ChecksHistoryRepository = _ChecksHistoryRepository;
        }

        public IBaseResponse<Checks_historyViewModel> CreateChecksHistory(Checks_historyViewModel checks_History)
        {
            try
            {
                var cHistory = ChecksHistoryRepository.Create(checks_History);
                if (ChecksHistoryRepository.GetAll()
                    .FirstOrDefault(chr => chr.roomNum == checks_History.roomNum
                    && chr.customer_phone == checks_History.customer_phone) != null)
                {
                    return new DBResponse<Checks_historyViewModel>
                    {
                        Description = "Обьект добавился!",
                        StatusCode = StatusCode.OK
                    };
                }

                return new DBResponse<Checks_historyViewModel>
                {
                    Description = "ОШИБКА!",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Checks_historyViewModel>
                {
                    Description = $"[CreateChecksHistory] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Checks_historyViewModel> DeleteChecksHistory(Checks_historyViewModel checks_History)
        {
            try
            {
                var cHistory = ChecksHistoryRepository.Delete(checks_History);
                if (ChecksHistoryRepository.GetAll()
                    .FirstOrDefault(chr => chr.id == checks_History.id) == null)
                {
                    return new DBResponse<Checks_historyViewModel>
                    {
                        Description = "Обьект удалился!",
                        StatusCode = StatusCode.OK
                    };
                }

                return new DBResponse<Checks_historyViewModel>
                {
                    Description = "ОШИБКА!",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Checks_historyViewModel>
                {
                    Description = $"[DeleteChecksHistory] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Checks_historyViewModel> EditChecksHistory(Checks_historyViewModel checks_History)
        {
            try
            {
                var cHistory = ChecksHistoryRepository
                .Edit(checks_History, checks_History.id);

                if (ChecksHistoryRepository.GetAll()
                    .FirstOrDefault(chr => chr.id == checks_History.id) == checks_History)
                {
                    return new DBResponse<Checks_historyViewModel>
                    {
                        Description = "Обьект изменился!",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Checks_historyViewModel>
                {
                    Description = "ОШИБКА!",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Checks_historyViewModel>
                {
                    Description = $"[EditChecksHistory] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<Checks_historyViewModel>> GetChecksHistories()
        {
            try
            {
                var cHistories = ChecksHistoryRepository.GetAll();
                if (cHistories.Count() != 0)
                {
                    return new DBResponse<IEnumerable<Checks_historyViewModel>>
                    {
                        Data = cHistories,
                        Description = "Обьект изменился!",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<Checks_historyViewModel>>
                {
                    Description = "Список пуст!",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Checks_historyViewModel>>
                {
                    Description = $"[EditChecksHistory] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<Checks_historyViewModel>> GetChecksHistories(Checks_historyViewModel checks_History)
        {
            throw new NotImplementedException();
        }
    }
}
