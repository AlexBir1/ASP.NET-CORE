using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Entities;
using WEBSHOP.Domain.Enums;

namespace WEBSHOP.Domain.ViewModels
{
    public class OrdersViewModel
    {
        public int Id { get; set; }
        public UserViewModel Owner { get; set; }
        public int FullCost { get; set; }
        public DateTime DateCreate { get; set; }
        public OrderStatus Status { get; set; }
        public List<ProductViewModel> ProductsIn { get; set; }
    }
}
