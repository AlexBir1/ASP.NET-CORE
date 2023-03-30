using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Entities;

namespace WEBSHOP.Domain.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }
        public string PicturePath { get; set; }
        public string ProductType { get; set; }
        public string ProductManufactorer { get; set; }
        public string ProductUnit { get; set; }
    }
}
