using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Models
{
    public class ProfilesViewModel
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public UserStatus status { get; set; }
    }
}
