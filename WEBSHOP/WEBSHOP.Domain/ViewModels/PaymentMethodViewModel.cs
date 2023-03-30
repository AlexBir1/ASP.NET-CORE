using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.ViewModels
{
    public class PaymentMethodViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string CardExpirationMonth { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string CardExpirationYear { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string CardCVV { get; set; }
        public int User_Id { get; set; }
    }
}
