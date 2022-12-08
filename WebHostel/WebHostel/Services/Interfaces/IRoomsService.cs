using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IRoomsService
    {
        public IBaseResponse<RoomsViewModel> CreateRooms(RoomsViewModel _Rooms);
        public IBaseResponse<RoomsViewModel> EditRooms(RoomsViewModel _Rooms);
        public IBaseResponse<RoomsViewModel> DeleteRooms(RoomsViewModel _Rooms);
        public IBaseResponse<RoomsViewModel> GetRooms(string Rooms_num, string hostel_name);
        public IBaseResponse<IEnumerable<RoomsViewModel>> GetRoomss();
        public IBaseResponse<IEnumerable<RoomsViewModel>> GetRoomss(string hostel_name);
    }
}
