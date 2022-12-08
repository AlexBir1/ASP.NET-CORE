using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Domain.Entity
{
    public class Checks_history
    {
        public int id { get; set; }
        public string customer_phone { get; set; }
        public DateTime checkin_date { get; set; }
        public DateTime checkout_date { get; set; }
        public int roomNum { get; set; }
        public int roomRank { get; set; }
        public int cost { get; set; }
        public int wasBooked { get; set; }
        public int wasPrivate { get; set; }
        public int hostel_id { get; set; }
    }
}
