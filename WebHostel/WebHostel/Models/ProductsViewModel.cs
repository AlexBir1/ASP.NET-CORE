using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class ProductsViewModel
    {
        public int id { get; set; }
        public string specie { get; set; }
        public string title { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }
        public string wirehouse_name { get; set; }
    }
}
