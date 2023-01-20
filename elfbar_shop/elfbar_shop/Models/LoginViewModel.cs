using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public string login { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public string password { get; set; }
    }
}
