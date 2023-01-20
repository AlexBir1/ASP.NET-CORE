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
    public class WirehousesService : IWirehousesService
    {
        private readonly AppDBContext dbase;

        public WirehousesService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<WirehousesViewModel> CreateW(WirehousesViewModel w)
        {
            throw new NotImplementedException();
        }

        public IBaseResponse<WirehousesViewModel> DeleteW(WirehousesViewModel w)
        {
            throw new NotImplementedException();
        }

        public IBaseResponse<WirehousesViewModel> EditW(WirehousesViewModel w)
        {
            try
            {
                var type = dbase.Types.Where(t => t.title == w.type_name)
                    .AsNoTracking().FirstOrDefault();

                var profile = dbase.Profiles.Where(p => p.alias == w.owner_alias)
                    .AsNoTracking().FirstOrDefault();

                var prod = new Wirehouses
                {
                    id = w.id,
                    title = w.title,
                    cost = w.cost,
                    quantity = w.quantity,
                    profiles_id = profile.id,
                    types_id = type.id
                };
                dbase.Wirehouses.Update(prod);
                dbase.SaveChanges();

                if (dbase.Wirehouses.Where(d => d.id == w.id).FirstOrDefault() != null)
                {
                    return new DBResponse<WirehousesViewModel>
                    {
                        StatusCode = StatusCodes.OK,
                        Description = $"SUCCESS"
                    };
                }
                return new DBResponse<WirehousesViewModel>
                {
                    StatusCode = StatusCodes.InternalError,
                    Description = $"ERROR"
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<WirehousesViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<WirehousesPageViewModel>> GetWs()
        {
            try
            {
                var prods = await (from w in dbase.Wirehouses
                             join p in dbase.Profiles
                             on w.profiles_id equals p.id
                             join t in dbase.Types
                             on w.types_id equals t.id
                             select new WirehousesViewModel
                             {
                                 id = w.id,
                                 type_name = t.title,
                                 title = w.title,
                                 quantity = w.quantity,
                                 cost = w.cost,
                                 owner_alias = p.alias
                             }).ToListAsync();

                var Types = await (from t in dbase.Types
                             select new SelectListItem
                             {
                                 Text = t.title,
                                 Value = t.title
                             }).ToListAsync();

                var Owners = await (from p in dbase.Profiles
                             select new SelectListItem
                             {
                                 Text = p.alias,
                                 Value = p.alias
                             }).ToListAsync();

                if (prods.Count != 0 && Types.Count != 0)
                {
                    return new DBResponse<WirehousesPageViewModel>
                    {
                        Data = new WirehousesPageViewModel
                        {
                            ProductList = prods,
                            ProdTypes = Types,
                            OwnerList = Owners
                        },
                        Description = "SUCCESS!",
                        StatusCode = StatusCodes.OK
                    };
                }
                else
                    return new DBResponse<WirehousesPageViewModel>
                    {
                        Description = "Data is empty",
                        StatusCode = StatusCodes.DataIsEmpty
                    };
            }
            catch(Exception ex)
            {
                return new DBResponse<WirehousesPageViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }
    }
}
