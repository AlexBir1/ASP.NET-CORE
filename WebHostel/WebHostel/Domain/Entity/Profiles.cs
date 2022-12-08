using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Profiles
    {
        public int id { get; set; }
        public string login { get; set; }
        public string passw { get; set; }
        public int status { get; set; }
    }
}
