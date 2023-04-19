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
    public class GroupRepository : IGroupInterface
    {
        private readonly AppDbContext _db;

        public GroupRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IBaseResponse<Group>> Create(Group EntityToCreate)
        {
            try
            {
                _db.Group.Add(EntityToCreate);
                await _db.SaveChangesAsync();

                return new DBResponse<Group>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Group>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Group>> Delete(Group EntityToDelete)
        {
            try
            {
                _db.Group.Remove(EntityToDelete);
                await _db.SaveChangesAsync();

                return new DBResponse<Group>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Group>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Group>> Edit(Group EntityToEdit)
        {
            try
            {
                _db.Group.Update(EntityToEdit);
                await _db.SaveChangesAsync();

                return new DBResponse<Group>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Group>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Group>>> GetAll()
        {
            try
            {
                var groups = await _db.Group.ToListAsync();

                return new DBResponse<IEnumerable<Group>>
                {
                    IsSuccessful = true,
                    Data = groups
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Group>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Group>> GetById(int Id)
        {
            try
            {
                var group = await _db.Group.Include(x=>x.Teacher).Include(x=>x.Students).FirstOrDefaultAsync(x => x.Id == Id);
                return new DBResponse<Group>
                {
                    IsSuccessful = true,
                    Data = group
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Group>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }
    }
}
