using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Domain.Entities
{
    public class Spends
    {
        public int id { get; set; }
        public string spend_title { get; set; }
        public DateTime spend_date { get; set; }
        public int cost { get; set; }
    }
}
