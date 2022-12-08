using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class Employee_spendsViewModel
    {
        public int id { get; set; }
        public string employee_phone { get; set; }
        public int countofOperations { get; set; }
        public DateTime periodStart_date { get; set; }
        public DateTime periodEnd_date { get; set; }
        public int payment { get; set; }
        public string hostel_name { get; set; }
    }
}
