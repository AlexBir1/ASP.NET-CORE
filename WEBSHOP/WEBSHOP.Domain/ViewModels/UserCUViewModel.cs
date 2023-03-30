using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Enums;

namespace WEBSHOP.Domain.ViewModels
{
    public class UserCUViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string ShippingAddress { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public UnitViewModel MyUnit { get; set; }

        public SelectList Units { get; set; }
    }
}
