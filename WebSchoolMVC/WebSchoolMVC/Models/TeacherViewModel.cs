using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebSchoolMVC.Domain.Enum;

namespace WebSchoolMVC.Models
{
    public class TeacherViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fullname is empty")]
        [MinLength(8, ErrorMessage = "Fullname must be at least 8 charaters")]
        [MaxLength(45, ErrorMessage = "Fullname must not be longer than 45 characters")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Address is empty")]
        [MaxLength(100, ErrorMessage = "Address must not be longer than 100 characters")]
        public string Address { get; set; }

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

    }
}