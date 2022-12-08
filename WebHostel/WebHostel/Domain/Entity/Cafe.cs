using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Cafe
    {
        public int hostel_id { get; set; }
        public string title { get; set; }
    }
}
