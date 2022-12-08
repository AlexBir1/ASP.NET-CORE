using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    [Keyless]
    public class Services_info
    {
        public int services_id { get; set; }
        public string info { get; set; }
    }
}
