using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class ordered_productsViewModel
    {
        public int id { get; set; }
        public string specie { get; set; }
        public string title { get; set; }
        public DateTime order_date { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public string hostel_name { get; set; }
    }
}
