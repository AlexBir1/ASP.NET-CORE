using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Domain.Entities
{
    public class Profiles
    {
        public int id { get; set; }
        public string alias { get; set; }
        public string login { get; set; }
        public string passw { get; set; }
    }
}
