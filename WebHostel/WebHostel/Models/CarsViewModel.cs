using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class CarsViewModel
    {
        public int id { get; set; }
        public string specie { get; set; }
        public string firm { get; set; }
        public string num { get; set; }
        public int FuelType { get; set; }
        public float FuelPer100 { get; set; }
        public string hostel_name { get; set; }
    }
}
