using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.Domain;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Interfaces
{
    public interface IStudentInterface : IBaseInterface<Student>
    {
        public Task<SelectList> GetGroupsForSelection();
        public Task<SelectList> GetGroupsForSelection(string selectedValue);
        public Task<IBaseResponse<ClaimsIdentity>> FindAndAuthenticate(string Login, string Password);
    }
}
