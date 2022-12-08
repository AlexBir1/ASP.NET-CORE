using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class orders_historyViewModel
    {
        public int id { get; set; }
        public string customer_phone { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }

        public DateTime order_date { get; set; }

        public string employee_phone { get; set; }
        public string hostel_name { get; set; }
    }
}
