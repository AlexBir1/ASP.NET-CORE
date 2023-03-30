using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.ViewModels
{
    public class ManufactorerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string Address { get; set; }
    }
}
