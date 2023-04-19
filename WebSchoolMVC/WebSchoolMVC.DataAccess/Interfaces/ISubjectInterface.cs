using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.Domain;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Interfaces
{
    public interface ISubjectInterface : IBaseInterface<Subject>
    {
        public Task<IBaseResponse<IEnumerable<Subject>>> GetAllByTeacherId(int Teacher_Id);
        public Task<IBaseResponse<Subject>> AddTeacher(int Subject_Id, int Teacher_Id);
        public Task<IBaseResponse<Subject>> RemoveTeacher(int Subject_Id, int Teacher_Id);
    }
}
