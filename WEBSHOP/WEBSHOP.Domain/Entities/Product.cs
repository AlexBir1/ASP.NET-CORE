using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }
        public string PicturePath { get; set; }
        public int Type_Id { get; set; }
        public int Manufactorer_Id { get; set; }
        public int Unit_Id { get; set; }

    }
}
