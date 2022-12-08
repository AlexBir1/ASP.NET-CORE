using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Services_history
    {
        public int id { get; set; }
        public string customer_num { get; set; }
        public string employee_num { get; set; }
        public string stitle { get; set; }
        public DateTime service_date { get; set; }
        public int cost { get; set; }
        public int hostel_id { get; set; }
    }
}
