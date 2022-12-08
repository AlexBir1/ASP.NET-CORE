using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Domain.Entity
{
    public class Orders
    {
        public int id { get; set; }
        public string customer_num { get; set; }
        public string title { get; set; }
        public int cost { get; set; }
        public int quantity { get; set; }
        public OrdersStatuses status { get; set; }
        public int cafe_employees_id { get; set; }
    }
}
