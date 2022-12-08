using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class DishesViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string ingreds { get; set; }
        public int? cost { get; set; }
        public string cafe_name { get; set; }
    }
}
