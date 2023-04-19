using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSchoolMVC.Domain.Entity;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess.Interfaces
{
    public interface IRoomInterface : IBaseInterface<Room>
    {
        IBaseResponse<Room> AddCaretaker(int Id, int Teacher_Id);
        IBaseResponse<Room> RemoveCaretaker(int Id);
    }
}
