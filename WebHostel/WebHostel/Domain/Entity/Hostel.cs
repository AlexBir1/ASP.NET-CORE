using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Hostel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string location { get; set; }
    }
}
