using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Models
{
    public class WERegisterViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ ФИО!")]
        [StringLength(42, MinimumLength = 1, ErrorMessage = "Диапазон символов : 1-42")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ НОМЕР ТЕЛЕФОНА!")]
        [StringLength(42, MinimumLength = 1, ErrorMessage = "Диапазон символов : 1-42")]
        public string phone { get; set; }

        public WEmployeeRanks rank { get; set; }

        public string wirehouse_name { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ ЛОГИН!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Диапазон символов : 8-20")]
        public string login { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ ПАРОЛЬ!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Диапазон символов : 8-20")]
        public string password { get; set; }

        [Required(ErrorMessage = "ПОВТОРИТЕ ПАРОЛЬ!")]
        [Compare("password", ErrorMessage = "Пароли не совпадают")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Диапазон символов : 8-20")]
        public string Confirm_password { get; set; }

        public UserStatus status { get; set; }
    }
}
