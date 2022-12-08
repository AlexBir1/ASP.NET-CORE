using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Manufactorer
    {
        public int id { get; set; }
        public string title { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}
