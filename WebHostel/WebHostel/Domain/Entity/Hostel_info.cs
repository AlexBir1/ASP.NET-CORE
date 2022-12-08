using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    [Keyless]
    public class Hostel_info
    {
        public int? hostel_id { get; set; }
        public string info { get; set; }
    }
}
