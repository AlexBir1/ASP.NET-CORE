using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Employee_spends
    {
        public int id { get; set; }
        public string employee_phone { get; set; }
        public int countofOperations { get; set; }
        public DateTime sdate { get; set; }
        public DateTime fdate { get; set; }
        public int payment { get; set; }
        public int hostel_id { get; set; }
    }
}
