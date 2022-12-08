﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class Checks_historyViewModel
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
        public string hostel_name { get; set; }
    }
}
