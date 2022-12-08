using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Booking
    {
        public int id { get; set; }
        public DateTime book_date { get; set; }
        public string customer_phone { get; set; }
        public int rooms_id { get; set; }
    }
}
