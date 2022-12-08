using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class worders
    {
        public int id { get; set; }
        public string specie { get; set; }
        public string title { get; set; }
        public DateTime order_date { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public int status { get; set; }
        public string employee_num { get; set; }
        public int wirehouse_hostel_id { get; set; }
        public int manufactorer_id { get; set; }
    }
}
