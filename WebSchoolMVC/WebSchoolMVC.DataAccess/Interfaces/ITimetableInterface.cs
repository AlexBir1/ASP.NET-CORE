using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Interfaces
{
    public interface ITimetableInterface : IBaseInterface<Timetable>
    {
        public Task<IBaseResponse<SelectList>> GetGroupSelectList(int Group_Id = 0);
        public Task<IBaseResponse<SelectList>> GetSubjectSelectList(int Subject_Id = 0);
        public Task<IBaseResponse<SelectList>> GetRoomSelectList(int Room_Id = 0);


    }
}
