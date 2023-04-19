using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolMVC.Models
{
    public class AdminsViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fullname is empty")]
        [MinLength(8, ErrorMessage = "Fullname must be at least 8 charaters")]
        [MaxLength(45, ErrorMessage = "Fullname must not be longer than 45 characters")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Mobile number is empty")]
        [MinLength(8, ErrorMessage = "Mobile number must be at least 8 charaters")]
        [MaxLength(20, ErrorMessage = "Mobile number must not be longer than 20 characters")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Login field is empty")]
        [MinLength(8, ErrorMessage = "Login must be at least 8 charaters")]
        [MaxLength(20, ErrorMessage = "Login must not be longer than 20 characters")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password field is empty")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 charaters")]
        [MaxLength(20, ErrorMessage = "Password must not be longer than 20 characters")]
        public string Password { get; set; }

        public int Status { get; set; }
    }
}
