using elfbar_shop.Domain.Entities;
using elfbar_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using elfbar_shop.DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using elfbar_shop.Domain.Response;
using System.Threading.Tasks;

namespace elfbar_shop.DAL.Services.Implements
{
    public class SpendsService : ISpendsService
    {
        private readonly AppDBContext dbase;

        public SpendsService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<SpendsViewModel> CreateSpend(SpendsViewModel _spend)
        {
            try
            {
                var _Spend = new Spends
                {
                    id = _spend.id,
                    spend_title = _spend.spend_title,
                    spend_date = _spend.spend_date,
                    cost = _spend.cost
                };
                dbase.Spends.Add(_Spend);
                dbase.SaveChanges();
                if (dbase.Spends.Where(d => d.spend_title == _spend.spend_title && d.spend_date == _spend.spend_date).AsNoTracking().FirstOrDefault() != null)
                    return new DBResponse<SpendsViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<SpendsViewModel>
                {
                    Description = "Error!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<SpendsViewModel>
                {
                    Description = $"Error: {ex.Message}",
                };
            }
        }

        public IBaseResponse<SpendsViewModel> DeleteSpend(SpendsViewModel _spend)
        {
            try
            {
                var _Spend = new Spends
                {
                    id = _spend.id,
                    spend_title = _spend.spend_title,
                    spend_date = _spend.spend_date,
                    cost = _spend.cost
                };
                dbase.Spends.Remove(_Spend);
                dbase.SaveChanges();
                if (dbase.Spends.Where(d => d.id == _spend.id).AsNoTracking().FirstOrDefault() == null)
                    return new DBResponse<SpendsViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<SpendsViewModel>
                {
                    Description = "Error!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<SpendsViewModel>
                {
                    Description = $"Error: {ex.Message}",
                };
            }
        }

        public IBaseResponse<SpendsViewModel> EditSpend(SpendsViewModel _spend)
        {
            try
            {
                var _Spend = new Spends
                {
                    id = _spend.id,
                    spend_title = _spend.spend_title,
                    spend_date = _spend.spend_date,
                    cost = _spend.cost
                };
                dbase.Spends.Update(_Spend);
                dbase.SaveChanges();
                if (dbase.Spends.Where(d => d.id == _Spend.id).AsNoTracking().FirstOrDefault() != null)
                    return new DBResponse<SpendsViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<SpendsViewModel>
                {
                    Description = "Error!",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<SpendsViewModel>
                {
                    Description = $"Error: {ex.Message}",
                };
            }
        }

        public async Task<IBaseResponse<SpendsPageViewModel>> GetSpends()
        {
            try
            {
                var _Spends = await (from s in dbase.Spends
                                  select new SpendsViewModel
                                 {
                                      id = s.id,
                                      spend_title = s.spend_title,
                                      spend_date = s.spend_date,
                                      cost = s.cost
                                  }).ToListAsync();
                dbase.Dispose();
                if (_Spends.Count != 0)
                    return new DBResponse<SpendsPageViewModel>
                    {
                        Data = new SpendsPageViewModel
                        {
                            SpendList = _Spends
                        },
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<SpendsPageViewModel>
                {
                    Description = "НЕ БУЛО ЖОДНОГО ПРОГАВА",
                    StatusCode = StatusCodes.DataIsEmpty
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<SpendsPageViewModel>
                {
                    Description = $"Error: {ex.Message}",
                };
            }
        }
    }
}
