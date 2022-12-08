using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class ServicesViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string info { get; set; } 
        public int cost { get; set; }
        public int isDriving { get; set; }
        public int employee_rank { get; set; }
        public string hostel_name { get; set; }
    }
}
