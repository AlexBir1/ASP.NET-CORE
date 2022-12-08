using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Models
{
    public class wordersViewModel
    {
        public int id { get; set; }


        public string specie { get; set; }

        public string title { get; set; }


        public DateTime order_date { get; set; }
        public int quantity { get; set; }
        public int cost { get; set; }

        public WOStatuses status { get; set; }

        public string employee_num { get; set; }

        public string wirehouse_name { get; set; }

        public string manufactorer_name { get; set; }
    }
}
