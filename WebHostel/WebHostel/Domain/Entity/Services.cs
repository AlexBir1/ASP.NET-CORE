using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Service
    {
        public int id { get; set; }
        public string title { get; set; }
        public int cost { get; set; }
        public int isDriving { get; set; }
        public int employee_rank { get; set; }
        public int hostel_id { get; set; }
    }
}
