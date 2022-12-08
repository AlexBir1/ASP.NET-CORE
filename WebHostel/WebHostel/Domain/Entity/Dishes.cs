using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Dishes
    {
        public int id { get; set; }
        public string title { get; set; }
        public string ingreds { get; set; }
        public int? cost { get; set; }
        public int cafe_hostel_id { get; set; }
    }
}
