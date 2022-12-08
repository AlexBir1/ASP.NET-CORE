using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class ChosenServicesViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int cost { get; set; }
        public int status { get; set; }
        public string hostel_name { get; set; }
        public string customer_num { get; set; }
        public string employee_num { get; set; }
    }
}
