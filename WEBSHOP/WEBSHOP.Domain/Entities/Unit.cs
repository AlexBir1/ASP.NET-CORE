using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.Domain.Entities
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
