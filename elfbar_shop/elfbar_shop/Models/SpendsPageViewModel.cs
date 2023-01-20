using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class SpendsPageViewModel
    {
        public int id { get; set; }
        public string spend_title { get; set; }
        public DateTime spend_date { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public int cost { get; set; }

        public List<SpendsViewModel> SpendList { get; set; }
    }
}
