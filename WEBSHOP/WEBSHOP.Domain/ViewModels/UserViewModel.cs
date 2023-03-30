using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.Enums;

namespace WEBSHOP.Domain.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string ShippingAddress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public UnitViewModel MyUnit { get; set; }
    }
}
