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
    public class LaughService : ILaughService
    {
        private readonly AppDBContext dbase;

        public LaughService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<LaughViewModel> CreateL(LaughViewModel laugh)
        {
            try
            {
                var Laugh = new Laugh
                {
                    str = laugh.str
                };

                dbase.Laugh.Add(Laugh);
                dbase.SaveChanges();

                if (dbase.Laugh.Where(l => l.str == laugh.str).FirstOrDefault() != null)
                {
                    dbase.Dispose();
                    return new DBResponse<LaughViewModel>
                    {
                        StatusCode = StatusCodes.OK,
                        Description = "SUCCESS"
                    };
                }
                return new DBResponse<LaughViewModel>
                {
                    StatusCode = StatusCodes.InternalError,
                    Description = "Error!"
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<LaughViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<LaughViewModel> DeleteL(LaughViewModel laugh)
        {
            try
            {
                var Laugh = new Laugh
                {
                    id = laugh.id,
                    str = laugh.str
                };

                dbase.Laugh.Remove(Laugh);
                dbase.SaveChanges();

                if (dbase.Laugh.Where(l => l.id == laugh.id).FirstOrDefault() == null)
                {
                    dbase.Dispose();
                    return new DBResponse<LaughViewModel>
                    {
                        StatusCode = StatusCodes.OK,
                        Description = "SUCCESS"
                    };
                }
                return new DBResponse<LaughViewModel>
                {
                    StatusCode = StatusCodes.InternalError,
                    Description = "Error!"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<LaughViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<LaughPageViewModel> GetLs()
        {
            Random r = new Random();
            try
            {
                var Ls = dbase.Laugh.Select(l => new LaughViewModel
                {
                    id = l.id,
                    str = l.str
                }).ToList();

                int val = r.Next(0, Ls.Count);
                dbase.Dispose();

                if (Ls.Count != 0)
                    return new DBResponse<LaughPageViewModel>
                    {
                        Data = new LaughPageViewModel
                        {
                            _Laugh = Ls[val]
                        },
                        StatusCode = StatusCodes.OK,
                        Description = "SUCCESS"
                    };
                return new DBResponse<LaughPageViewModel>
                {
                    StatusCode = StatusCodes.InternalError,
                    Description = "ТУТА ПУСТО"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<LaughPageViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }
    }
}
