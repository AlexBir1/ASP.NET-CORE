using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Employees
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public int rank { get; set; }
        public int hostel_id { get; set; }
        public int profiles_id { get; set; }
    }
}
