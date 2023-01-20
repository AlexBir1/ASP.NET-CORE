using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Domain.Entities
{
    public class Wirehouses
    {
        public int id { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public int types_id { get; set; }
        public int profiles_id { get; set; }
    }
}
