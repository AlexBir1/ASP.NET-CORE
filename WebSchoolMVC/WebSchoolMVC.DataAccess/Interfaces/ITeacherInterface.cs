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
    public interface ITeacherInterface : IBaseInterface<Teacher>
    {
        public Task<IBaseResponse<ClaimsIdentity>> FindAndAuthenticate(string Login, string Password);
    }
}
