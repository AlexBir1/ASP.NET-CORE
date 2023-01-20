using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class OrderHistoryViewModel
    {
        public int id { get; set; }
        public string product_type { get; set; }
        public string product_name { get; set; }
        public int cost { get; set; }
        public DateTime order_date { get; set; }
        public string seller_alias { get; set; }
    }
}
