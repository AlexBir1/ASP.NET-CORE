using elfbar_shop.Domain.Entities;
using elfbar_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using elfbar_shop.DAL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using elfbar_shop.Domain.Response;

namespace elfbar_shop.DAL.Services.Implements
{
    public class Sell_InfoService : ISell_InfoService
    {
        private readonly AppDBContext dbase;

        public Sell_InfoService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<Sell_InfoViewModel> CreateSell_info(Sell_InfoViewModel sell_Info)
        {
            try
            {
                var SELLINFO = new Sell_info
                {
                    id = sell_Info.id,
                    curbalance = sell_Info.curbalance,
                    reqbalance = sell_Info.reqbalance
                };
                dbase.Sell_info.Add(SELLINFO);
                dbase.SaveChanges();
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = "SUCCESS!",
                    StatusCode = StatusCodes.OK
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<Sell_InfoViewModel> DeleteSell_info(Sell_InfoViewModel sell_Info)
        {
            try
            {
                var SELLINFO = dbase.Sell_info.Where(si => si.id == sell_Info.id).AsNoTracking().FirstOrDefault();
                dbase.Sell_info.Remove(SELLINFO);
                dbase.SaveChanges();
                if(dbase.Sell_info.Where(si => si.id == sell_Info.id).AsNoTracking().FirstOrDefault() == null)
                    return new DBResponse<Sell_InfoViewModel>
                    {
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<Sell_InfoViewModel> EditSell_info(Sell_InfoViewModel sell_Info)
        {
            try
            {
                var SELLINFO = new Sell_info
                {
                    id = sell_Info.id,
                    curbalance = sell_Info.curbalance,
                    reqbalance = sell_Info.reqbalance
                };
                dbase.Sell_info.Update(SELLINFO);
                dbase.SaveChanges();
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = "SUCCESS!",
                    StatusCode = StatusCodes.OK
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<Sell_InfoViewModel> GetSell_info()
        {
            try
            {
                var sell_info = (from si in dbase.Sell_info
                                 select new Sell_InfoViewModel
                                 {
                                     id = si.id,
                                     curbalance = si.curbalance,
                                     reqbalance = si.reqbalance
                                 }).Where(s=>s.id == 1).AsNoTracking().FirstOrDefault();
                dbase.Dispose();
                if (sell_info != null)
                    return new DBResponse<Sell_InfoViewModel>
                    {
                        Data = sell_info,
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.DataIsEmpty
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<Sell_InfoViewModel> SetRBalance()
        {
            try
            {
                dbase.Database.ExecuteSqlRaw($"call SetRBalance()");

                var si = (from s in dbase.Sell_info
                          select new Sell_InfoViewModel
                          {
                              id = s.id,
                              curbalance = s.curbalance,
                              reqbalance = s.reqbalance
                          }).Where(_s => _s.id == 1).FirstOrDefault();

                return new DBResponse<Sell_InfoViewModel>
                {
                    Data = si,
                    StatusCode = StatusCodes.OK,
                    Description = "БАЛАНС ВИРАХУВАНО"
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<Sell_InfoViewModel>
                {
                    Description = $"Error, якась САСАМБА: {ex.Message}"
                };
            }
        }
    }
}
