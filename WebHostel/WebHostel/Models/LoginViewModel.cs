using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "УКАЖИТЕ ЛОГИН!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Диапазон символов : 8-20")]
        public string login { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ ПАРОЛЬ!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Диапазон символов : 8-20")]
        public string password { get; set; }
    }
}
