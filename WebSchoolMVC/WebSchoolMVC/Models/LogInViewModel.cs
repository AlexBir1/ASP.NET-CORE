using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolMVC.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Login filed is empty")]
        [MinLength(8, ErrorMessage = "Login must be at least 8 charaters")]
        [MaxLength(20, ErrorMessage = "Login must not be longer than 20 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password filed is empty")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 charaters")]
        [MaxLength(20, ErrorMessage = "Password must not be longer than 20 characters")]
        public string Password { get; set; }
    }
}
