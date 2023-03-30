using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.Entities
{
    public class Bin
    {
        [Key]
        public int Id { get; set; }

        public int User_Id { get; set; }
        public int Product_Id { get; set; }
    }
}
