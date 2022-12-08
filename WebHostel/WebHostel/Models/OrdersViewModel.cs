using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Models
{
    public class OrdersViewModel
    {
        public int id { get; set; }
        public string customer_num { get; set; }
        public string title { get; set; }
        public int cost { get; set; }
        public int quantity { get; set; }
        public OrdersStatuses status { get; set; }
        public string cafe_employees_num { get; set; }
    }
}
