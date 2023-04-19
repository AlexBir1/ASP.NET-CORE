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
    public class JournalRepository : IJournalInterface
    {
        private readonly AppDbContext _db;

        public JournalRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IBaseResponse<Journal>> Create(Journal EntityToCreate)
        {
            try
            {
                _db.Journal.Add(EntityToCreate);
                await _db.SaveChangesAsync();

                return new DBResponse<Journal>
                {
                    IsSuccessful = true
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<Journal>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Journal>> Delete(Journal EntityToDelete)
        {
            try
            {
                _db.Journal.Remove(EntityToDelete);
                await _db.SaveChangesAsync();

                return new DBResponse<Journal>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Journal>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Journal>> Edit(Journal EntityToEdit)
        {
            try
            {
                _db.Journal.Update(EntityToEdit);
                await _db.SaveChangesAsync();

                return new DBResponse<Journal>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Journal>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Journal>>> GetAll()
        {
            try
            {
                var journalNotes = await _db.Journal.Include(x => x.Student).Include(x => x.Subject).Select(x=>new Journal 
                {
                    Id = x.Id,
                    Mark = x.Mark,
                    MarkingDate = x.MarkingDate,
                    Student_Id = x.Student_Id,
                    Subject_Id = x.Subject_Id,
                    Student = new Student
                    {
                        Id = x.Student.Id,
                        Fullname = x.Student.Fullname,
                        MobileNumber = x.Student.MobileNumber
                    },
                    Subject = new Subject
                    {
                        Id = x.Id,
                        Title = x.Subject.Title
                    }
                }).ToListAsync();

                return new DBResponse<IEnumerable<Journal>>
                {
                    IsSuccessful = true,
                    Data = journalNotes
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Journal>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Journal>>> GetAllByStudentId(int Student_Id)
        {
            try
            {
                var journalNotes = await _db.Journal.Include(x => x.Student).Include(x => x.Subject).Where(x=>x.Student.Id == Student_Id).Select(x => new Journal
                {
                    Id = x.Id,
                    Mark = x.Mark,
                    MarkingDate = x.MarkingDate,
                    Student_Id = x.Student_Id,
                    Subject_Id = x.Subject_Id,
                    Student = new Student
                    {
                        Id = x.Student.Id,
                        Fullname = x.Student.Fullname,
                        MobileNumber = x.Student.MobileNumber
                    },
                    Subject = new Subject
                    {
                        Id = x.Id,
                        Title = x.Subject.Title
                    }
                }).ToListAsync();

                return new DBResponse<IEnumerable<Journal>>
                {
                    IsSuccessful = true,
                    Data = journalNotes
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Journal>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Journal>> GetById(int Id)
        {
            try
            {
                var journalNote = await _db.Journal.Include(x=>x.Student).Include(x => x.Subject).FirstAsync(x => x.Id == Id);

                return new DBResponse<Journal>
                {
                    IsSuccessful = true,
                    Data = journalNote
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Journal>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Subject>>> GetSubjectsByTeacherId(int Teacher_Id)
        {
            try
            {
                var subjects = await _db.Subject
                    .Include(x => x.SubjectHasTeachers)
                    .Where(x => x.SubjectHasTeachers.Any(x => x.Teacher.Id == Teacher_Id))
                    .ToListAsync();

                return new DBResponse<IEnumerable<Subject>>
                {
                    IsSuccessful = false,
                    Data = subjects
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<IEnumerable<Subject>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }
    }
}
