using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Entities;

namespace WEBSHOP.Domain.ViewModels
{
    public class BinViewModel
    {
        public int Id { get; set; }
        public UserViewModel Owner { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
