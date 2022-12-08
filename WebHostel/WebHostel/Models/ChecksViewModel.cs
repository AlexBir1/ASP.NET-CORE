using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class ChecksViewModel
    {
        public int id { get; set; }
        public DateTime checkin_date { get; set; }
        public DateTime checkout_date { get; set; }
        public int isPrivate { get; set; }
        public int isBooked { get; set; }
        public int rooms_num { get; set; }

        [Required(ErrorMessage = "Укажите номер клиента")]
        public string customer_num { get; set; }
    }
}
