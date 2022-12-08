using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Wirehouse_employees
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public int rank { get; set; }
        public int wirehouse_hostel_id { get; set; }
        public int profiles_id { get; set; }
    }
}
