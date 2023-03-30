using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.Enums;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.Domain.Entities
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }
        public int FullCost { get; set; }
        public int Status { get; set; }
        public int User_Id { get; set; }

    }
}
