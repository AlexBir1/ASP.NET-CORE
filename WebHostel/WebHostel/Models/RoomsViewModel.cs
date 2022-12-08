using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Models
{
    public class RoomsViewModel
    {
        public int id { get; set; }
        public int num { get; set; }
        public RoomRanks rank { get; set; }
        public int CostPerDay { get; set; }
        public int maxPeople { get; set; }
        public string hostel_name { get; set; }
        public StatusCode StatusCode { get; internal set; }
    }
}
