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
    public class RoomRepository : IRoomInterface
    {
        private readonly AppDbContext _db;

        public RoomRepository(AppDbContext db)
        {
            _db = db;
        }

        public IBaseResponse<Room> AddCaretaker(int Id, int Teacher_Id)
        {
            try
            {
                var room = _db.Room.First(x=>x.Id == Id);
                _db.Room.Attach(room);
                room.Teacher_Id = Teacher_Id;
                _db.SaveChanges();
                return new DBResponse<Room> { IsSuccessful = true };
            }
            catch(Exception ex)
            {
                return new DBResponse<Room>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Room>> Create(Room EntityToCreate)
        {
            try
            {
                _db.Room.Add(EntityToCreate);
                await _db.SaveChangesAsync();

                return new DBResponse<Room> { IsSuccessful = true };
            }
            catch(Exception ex)
            {
                return new DBResponse<Room>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Room>> Delete(Room EntityToDelete)
        {
            try
            {
                _db.Room.Remove(EntityToDelete);
                await _db.SaveChangesAsync();

                return new DBResponse<Room> { IsSuccessful = true };
            }
            catch (Exception ex)
            {
                return new DBResponse<Room>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Room>> Edit(Room EntityToEdit)
        {
            try
            {
                _db.Room.Update(EntityToEdit);
                await _db.SaveChangesAsync();

                return new DBResponse<Room> { IsSuccessful = true };
            }
            catch (Exception ex)
            {
                return new DBResponse<Room> 
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Room>>> GetAll()
        {
            try
            {
                var rooms = await _db.Room.ToListAsync();

                return new DBResponse<IEnumerable<Room>>
                {
                    IsSuccessful = true,
                    Data = rooms
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Room>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Room>> GetById(int Id)
        {
            try
            {
                var room = await _db.Room
                    .Include(a=>a.Teacher)
                    .FirstAsync(x=>x.Id == Id);

                return new DBResponse<Room>
                {
                    IsSuccessful = true,
                    Data = room
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Room>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public IBaseResponse<Room> RemoveCaretaker(int Id)
        {
            try
            {
                var room = _db.Room.First(x => x.Id == Id);
                _db.Room.Attach(room);
                room.Teacher_Id = null;
                _db.SaveChanges();
                return new DBResponse<Room> { IsSuccessful = true };
            }
            catch (Exception ex)
            {
                return new DBResponse<Room>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }
    }
}
