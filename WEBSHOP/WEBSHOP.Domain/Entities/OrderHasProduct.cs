using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.Entities
{
    public class OrderHasProduct
    {
        public int Id { get; set; }
        public int Orders_Id { get; set; }
        public int Product_Id { get; set; }
    }
}
