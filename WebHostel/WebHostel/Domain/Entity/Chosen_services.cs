using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class chosen_services
    {
        public int id { get; set; }
        public string chd_service { get; set; }
        public int cost { get; set; }
        public int status { get; set; }
        public string hostel_name { get; set; }
        public int customers_id { get; set; }
        public int employees_id { get; set; }
    }
}
