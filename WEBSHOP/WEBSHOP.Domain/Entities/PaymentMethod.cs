using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        public string CardNumber { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string CardCVV { get; set; }
        public int User_Id { get; set; }
    }
}
