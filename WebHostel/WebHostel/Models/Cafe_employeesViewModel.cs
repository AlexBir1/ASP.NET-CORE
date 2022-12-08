using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace WebHostel.Models
{
    public class Cafe_employeesViewModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public CEmployeeRanks rank { get; set; }
        public string cafe_name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public UserStatus status { get; set; }
    }
}
