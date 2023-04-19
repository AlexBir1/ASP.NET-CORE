using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Implementations
{
    public class TimetableRepository : ITimetableInterface
    {
        private readonly AppDbContext _db;

        public TimetableRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IBaseResponse<Timetable>> Create(Timetable EntityToCreate)
        {
            try
            {
                _db.Timetable.Add(EntityToCreate);
                await _db.SaveChangesAsync();

                return new DBResponse<Timetable>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Timetable>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Timetable>> Delete(Timetable EntityToDelete)
        {
            try
            {
                _db.Timetable.Remove(EntityToDelete);
                await _db.SaveChangesAsync();

                return new DBResponse<Timetable>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Timetable>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Timetable>> Edit(Timetable EntityToEdit)
        {
            try
            {
                _db.Timetable.Update(EntityToEdit);
                await _db.SaveChangesAsync();

                return new DBResponse<Timetable>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Timetable>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Timetable>>> GetAll()
        {
            try
            {
                var timetables = await _db.Timetable.Include(x => x.Group).Include(x => x.Subject).Include(x => x.Room).Select(x => new Timetable
                {
                    Id = x.Id,
                    StartDateTime = x.StartDateTime,
                    EndDateTime = x.EndDateTime,
                    Topic = x.Topic,
                    Group = new Group
                    {
                        Title = x.Group.Title
                    },
                    Room = new Room
                    {
                        Number = x.Room.Number
                    },
                    Subject = new Subject
                    {
                        Title = x.Subject.Title
                    }
                }).ToListAsync();

                return new DBResponse<IEnumerable<Timetable>>
                {
                    IsSuccessful = true,
                    Data = timetables
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Timetable>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Timetable>> GetById(int Id)
        {
            try
            {
                var timetable = await _db.Timetable.Include(x => x.Group).Include(x => x.Subject).Include(x => x.Room).FirstOrDefaultAsync(x => x.Id == Id);

                return new DBResponse<Timetable>
                {
                    IsSuccessful = true,
                    Data = timetable
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Timetable>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<SelectList>> GetGroupSelectList(int Group_Id = 0)
        {
            try
            {
                if (Group_Id == 0)
                    return new DBResponse<SelectList>
                    {
                        IsSuccessful = true,
                        Data = new SelectList(await _db.Group.Select(x => new Group
                        {
                            Id = x.Id,
                            Title = x.Title
                        }).ToListAsync(), "Id", "Title")
                    };
                return new DBResponse<SelectList>
                {
                    IsSuccessful = true,
                    Data = new SelectList(await _db.Group.Select(x => new Group
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToListAsync(), "Id", "Title", Group_Id)
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<SelectList>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<SelectList>> GetRoomSelectList(int Room_Id = 0)
        {
            if (Room_Id == 0)
                return new DBResponse<SelectList>
                {
                    IsSuccessful = true,
                    Data = new SelectList(await _db.Room.Select(x => new Room
                    {
                        Id = x.Id,
                        Number = x.Number
                    }).ToListAsync(), "Id", "Number")
                };
            return new DBResponse<SelectList>
            {
                IsSuccessful = true,
                Data = new SelectList(await _db.Room.Select(x => new Room
                {
                    Id = x.Id,
                    Number = x.Number
                }).ToListAsync(), "Id", "Number", Room_Id)
            };
        }

        public async Task<IBaseResponse<SelectList>> GetSubjectSelectList(int Subject_Id = 0)
        {
            if (Subject_Id == 0)
                return new DBResponse<SelectList>
                {
                    IsSuccessful = true,
                    Data = new SelectList(await _db.Subject.Select(x => new Subject
                    {
                        Id = x.Id,
                        Title = x.Title
                    }).ToListAsync(), "Id", "Title")
                };
            return new DBResponse<SelectList>
            {
                IsSuccessful = true,
                Data = new SelectList(await _db.Subject.Select(x => new Subject
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToListAsync(), "Id", "Title", Subject_Id)
            };
        }
    }
}
