using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class BookingViewModel
    {
        public int id { get; set; }
        public DateTime book_date { get; set; }
        public string customer_num { get; set; }
        public int room_num { get; set; }
    }
}
