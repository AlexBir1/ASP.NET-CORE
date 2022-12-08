using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Cafe_employees
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public int rank { get; set; }
        public int cafe_hostel_id { get; set; }
        public int profiles_id { get; set; }
    }
}
