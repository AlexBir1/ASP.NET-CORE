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
    public class TeacherRepository : ITeacherInterface
    {
        private readonly AppDbContext _db;

        public TeacherRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IBaseResponse<Teacher>> Create(Teacher EntityToCreate)
        {
            try
            {
                _db.Teacher.Add(EntityToCreate);
                await _db.SaveChangesAsync();

                return new DBResponse<Teacher>
                {
                    IsSuccessful = true
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<Teacher>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Teacher>> Delete(Teacher EntityToDelete)
        {
            try
            {
                _db.Teacher.Remove(EntityToDelete);
                await _db.SaveChangesAsync();

                return new DBResponse<Teacher>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Teacher>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Teacher>> Edit(Teacher EntityToEdit)
        {
            try
            {
                _db.Teacher.Update(EntityToEdit);
                await _db.SaveChangesAsync();

                return new DBResponse<Teacher>
                {
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Teacher>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Teacher>>> GetAll()
        {
            try
            {
                var teachers = await _db.Teacher.ToListAsync();

                return new DBResponse<IEnumerable<Teacher>>
                {
                    IsSuccessful = true,
                    Data = teachers
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Teacher>>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<Teacher>> GetById(int Id)
        {
            try
            {
                var teacher = await _db.Teacher
                    .Include(x=>x.Subjects)
                    .Include(x=>x.GroupUnderLeading)
                    .FirstOrDefaultAsync(x => x.Id == Id);

                return new DBResponse<Teacher>
                {
                    IsSuccessful = true,
                    Data = teacher
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Teacher>
                {
                    IsSuccessful = false,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<ClaimsIdentity>> FindAndAuthenticate(string Login, string Password)
        {
            try
            {
                var teacher = await _db.Teacher
                    .FirstAsync(x => x.Login == Login && x.Password == Password);

                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, teacher.Fullname),
                new Claim(ClaimTypes.Email, teacher.Login),
                new Claim(ClaimTypes.Sid, teacher.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, UserStatus.Teacher.ToString())
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
