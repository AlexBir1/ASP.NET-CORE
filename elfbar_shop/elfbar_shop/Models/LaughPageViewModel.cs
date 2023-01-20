using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class LaughPageViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public string str { get; set; }

        public LaughViewModel _Laugh { get; set; }
    }
}
