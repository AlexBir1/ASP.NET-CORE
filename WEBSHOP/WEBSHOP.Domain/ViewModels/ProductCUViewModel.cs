using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.ViewModels
{
    public class ProductCUViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Field is empty")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public int Cost { get; set; }

        public string PicturePath { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string ProductType { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string ProductManufactorer { get; set; }
        [Required(ErrorMessage = "Field is empty")]
        public string ProductUnit { get; set; }

        public SelectList selectType { get; set; }
        public SelectList selectUnit { get; set; }
        public SelectList selectMnf { get; set; }
    }
}
