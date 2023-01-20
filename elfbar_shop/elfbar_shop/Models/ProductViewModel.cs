using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class ProductViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public string title { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public int cost { get; set; }

        public int quantity { get; set; }
        public string type_name { get; set; }
    }
}
