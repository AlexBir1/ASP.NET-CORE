using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Rooms
    {
        public int id { get; set; }
        public int num{ get; set; }
        public int rank { get; set; }
        public int CostPerDay { get; set; }
        public int maxPeople { get; set; }
        public int hostel_id { get; set; }
    }
}
