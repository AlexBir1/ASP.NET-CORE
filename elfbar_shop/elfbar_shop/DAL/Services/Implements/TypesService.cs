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
    public class TypesService : ITypesService
    {
        private readonly AppDBContext dbase;

        public TypesService(AppDBContext _dbase)
        {
            dbase = _dbase;
        }

        public IBaseResponse<TypesViewModel> CreateType(TypesViewModel _type)
        {
            try
            {
                if (dbase.Types.Where(t => t.title.ToLower() == _type.title.ToLower()).FirstOrDefault() == null)
                {
                    dbase.Types.Add(new Types
                    {
                        id = _type.id,
                        title = _type.title
                    });
                    dbase.SaveChanges();
                    if (dbase.Types.Where(t => t.title == _type.title).AsNoTracking().FirstOrDefault() != null)
                        return new DBResponse<TypesViewModel>
                        {
                            Description = "SUCCESS",
                            StatusCode = StatusCodes.OK
                        };
                    return new DBResponse<TypesViewModel>
                    {
                        Description = "Error: сталась якась ху*ня",
                        StatusCode = StatusCodes.InternalError
                    };
                }
                return new DBResponse<TypesViewModel>
                {
                    Description = "Error: таке уже є в базі",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<TypesViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<TypesViewModel> DeleteType(TypesViewModel _type)
        {
            try
            {
                dbase.Types.Remove(new Types
                {
                    id = _type.id,
                    title = _type.title
                });
                dbase.SaveChanges();
                if (dbase.Types.Where(t => t.id == _type.id).AsNoTracking().FirstOrDefault() == null)
                    return new DBResponse<TypesViewModel>
                    {
                        Description = "SUCCESS",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<TypesViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<TypesViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public IBaseResponse<TypesViewModel> EditType(TypesViewModel _type)
        {
            try
            {
                dbase.Types.Update(new Types
                {
                    id = _type.id,
                    title = _type.title
                });
                dbase.SaveChanges();
                if (dbase.Types.Where(t => t.id == _type.id).AsNoTracking().FirstOrDefault().id == _type.id)
                    return new DBResponse<TypesViewModel>
                    {
                        Description = "SUCCESS",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<TypesViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.InternalError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<TypesViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<TypesPageViewModel>> GetTypes()
        {
            try
            {
                var Types = await (from t in dbase.Types
                             select new TypesViewModel
                             {
                                 id = t.id,
                                 title = t.title
                             }).ToListAsync();
                if (Types.Count != 0)
                    return new DBResponse<TypesPageViewModel>
                    {
                        Data = new TypesPageViewModel { TypeList = Types },
                        Description = "SUCCESS",
                        StatusCode = StatusCodes.OK
                    };
                return new DBResponse<TypesPageViewModel>
                {
                    Description = "Error",
                    StatusCode = StatusCodes.DataIsEmpty
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<TypesPageViewModel>
                {
                    Description = $"Error: {ex.Message}"
                };
            }
        }
    }
}
