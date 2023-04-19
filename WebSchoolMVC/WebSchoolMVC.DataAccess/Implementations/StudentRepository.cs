using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.DataAccess.Interfaces;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Enum;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Implementations
{
    public class StudentRepository : IStudentInterface
    {
        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IBaseResponse<Student>> Create(Student EntityToCreate)
        {
            try
            {
                _db.Student.Add(EntityToCreate);
                await _db.SaveChangesAsync();
                return new DBResponse<Student>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Student>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Student>> Delete(Student EntityToDelete)
        {
            try
            {
                _db.Student.Remove(EntityToDelete);
                await _db.SaveChangesAsync();
                return new DBResponse<Student>
                {
                    IsSuccessful = true,
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Student>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Student>> Edit(Student EntityToEdit)
        {
            try
            {
                _db.Student.Update(EntityToEdit);
                await _db.SaveChangesAsync();
                return new DBResponse<Student>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Student>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Student>>> GetAll()
        {
            try
            {
                var studentList = await _db.Student
                    .Include(x => x.Group)
                    .Select(x => new Student
                    {
                        Id = x.Id,
                        Fullname = x.Fullname,
                        MobileNumber = x.MobileNumber,
                        Group = x.Group,
                        Group_Id = x.Group_Id,
                    }).ToListAsync();
                return new DBResponse<IEnumerable<Student>>
                {
                    Data = studentList.ToList(),
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Student>>
                {
                    Description = ex.Message,
                    IsSuccessful = false
                };
            }
        }

        public async Task<IBaseResponse<Student>> GetById(int Id)
        {
            try
            {
                var student = await _db.Student.Include(s => s.Group).Select(x => new Student
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Address = x.Address,
                    Group = x.Group,
                    Group_Id = x.Group_Id,
                    Login = x.Login,
                    MobileNumber = x.MobileNumber,
                    Password = x.Password
                }).FirstOrDefaultAsync(x => x.Id == Id);
                return new DBResponse<Student>
                {
                    Data = student,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Student>
                {
                    Description = ex.Message,
                    IsSuccessful = false
                };
            }
        }

        public async Task<SelectList> GetGroupsForSelection()
        {
            return new SelectList(await _db.Group.ToListAsync(), "Id", "Title");
        }

        public async Task<SelectList> GetGroupsForSelection(string selectedValue)
        {
            return new SelectList(await _db.Group.ToListAsync(), "Id", "Title", selectedValue);
        }

        public async Task<IBaseResponse<ClaimsIdentity>> FindAndAuthenticate(string Login, string Password)
        {
            try
            {
                var student = await _db.Student
                    .FirstAsync(x => x.Login == Login && x.Password == Password);

                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, student.Fullname),
                new Claim(ClaimTypes.Email, student.Login),
                new Claim(ClaimTypes.Sid, student.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, UserStatus.Student.ToString())
            };
                return new DBResponse<ClaimsIdentity>
                {
                    Data = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType),
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Invalid login or password",
                    IsSuccessful = false
                };
            }
        }
    }
}
