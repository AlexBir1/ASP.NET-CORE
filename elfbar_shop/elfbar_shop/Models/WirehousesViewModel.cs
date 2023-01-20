using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class WirehousesViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public string type_name { get; set; }
        public string owner_alias { get; set; }
}
}
