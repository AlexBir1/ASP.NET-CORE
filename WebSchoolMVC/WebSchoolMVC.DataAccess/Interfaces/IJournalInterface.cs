using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Interfaces
{
    public interface IJournalInterface : IBaseInterface<Journal>
    {
        public Task<IBaseResponse<IEnumerable<Subject>>> GetSubjectsByTeacherId(int Teacher_Id);
        public Task<IBaseResponse<IEnumerable<Journal>>> GetAllByStudentId(int Student_Id);
    }
}
