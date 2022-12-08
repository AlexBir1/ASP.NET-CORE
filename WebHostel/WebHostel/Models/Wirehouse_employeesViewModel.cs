using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Models
{
    public class Wirehouse_employeesViewModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public WEmployeeRanks rank { get; set; }
        public string wirehouse_name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public UserStatus status { get; set; }
    }
}
