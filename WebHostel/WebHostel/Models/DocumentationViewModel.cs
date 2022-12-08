using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class DocumentationViewModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public int status { get; set; }
        public DateTime regdate { get; set; }
        public string fullstatus { get; set; }
        public string hostel_name { get; set; }
    }
}
