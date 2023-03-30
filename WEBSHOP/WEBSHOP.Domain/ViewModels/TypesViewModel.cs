using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.ViewModels
{
    public class TypesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        public string Title { get; set; }

        public string PicturePath { get; set; }
    }
}
