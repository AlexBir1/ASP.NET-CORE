using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Customers
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string hostel_name { get; set; }
        public int profiles_id { get; set; }
    }
}
