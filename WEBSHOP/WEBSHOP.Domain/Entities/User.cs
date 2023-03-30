using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Enums;

namespace WEBSHOP.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string ShippingAddress { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int? Unit_Id { get; set; }
        
    }
}
