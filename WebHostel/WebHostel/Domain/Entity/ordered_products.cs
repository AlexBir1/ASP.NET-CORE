using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class ordered_products
    {
        public int id { get; set; }
        public string specie { get; set; }
        public string title { get; set; }
        public DateTime order_date { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public int hostel_id { get; set; }
    }
}
