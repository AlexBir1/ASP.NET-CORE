using Microsoft.EntityFrameworkCore;
using System;

namespace WebHostel.Domain.Entity
{
    public class Checks
    {
        public int id { get; set; }
        public DateTime checkin_date { get; set; }
        public DateTime checkout_date { get; set; }
        public int isPrivate { get; set; }
        public int isBooked { get; set; }
        public int rooms_id { get; set; }
        public int customers_id { get; set; }
    }
}
