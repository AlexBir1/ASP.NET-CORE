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
    public class SubjectRepository : ISubjectInterface
    {
        private readonly AppDbContext _db;

        public SubjectRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IBaseResponse<Subject>> AddTeacher(int Subject_Id, int Teacher_Id)
        {
            try
            {
                _db.SubjectTeacher.Add(new SubjectTeacher { Subject_Id = Subject_Id, Teacher_Id = Teacher_Id });
                await _db.SaveChangesAsync();
                return new DBResponse<Subject>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Subject>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Subject>> Create(Subject EntityToCreate)
        {
            try
            {
                _db.Subject.Add(EntityToCreate);
                await _db.SaveChangesAsync();
                return new DBResponse<Subject>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Subject>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Subject>> Delete(Subject EntityToDelete)
        {
            try
            {
                _db.Subject.Remove(EntityToDelete);
                await _db.SaveChangesAsync();
                return new DBResponse<Subject>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Subject>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Subject>> Edit(Subject EntityToEdit)
        {
            try
            {
                _db.Subject.Update(EntityToEdit);
                await _db.SaveChangesAsync();
                return new DBResponse<Subject>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Subject>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Subject>>> GetAll()
        {
            try
            {
                var subjects = await _db.Subject.ToListAsync();
                return new DBResponse<IEnumerable<Subject>>
                {
                    IsSuccessful = true,
                    Data = subjects
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Subject>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Subject>>> GetAllByTeacherId(int Teacher_Id)
        {
            try
            {
                var subjects = await _db.Subject
                    .Include(x => x.SubjectHasTeachers)
                    .Where(x => x.SubjectHasTeachers.Any(x => x.Teacher.Id == Teacher_Id))
                    .ToListAsync();
                return new DBResponse<IEnumerable<Subject>>
                {
                    IsSuccessful = true,
                    Data = subjects
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Subject>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Subject>> GetById(int Id)
        {
            try
            {
                var subject = await _db.Subject.Include(x=>x.Teachers).FirstOrDefaultAsync(x => x.Id == Id);
                return new DBResponse<Subject>
                {
                    IsSuccessful = true,
                    Data = subject
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Subject>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Subject>> RemoveTeacher(int Subject_Id, int Teacher_Id)
        {
            try
            {
                _db.SubjectTeacher.Remove(new SubjectTeacher { Subject_Id = Subject_Id, Teacher_Id = Teacher_Id });
                await _db.SaveChangesAsync();
                return new DBResponse<Subject>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Subject>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }
    }
}
