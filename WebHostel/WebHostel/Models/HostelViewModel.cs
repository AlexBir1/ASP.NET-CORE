using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostel.Models
{
    public class HostelViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ НАЗВАНИЕ!")]
        [StringLength(42, MinimumLength = 1, ErrorMessage = "Диапазон символов : 1-42")]
        public string title { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ МЕСТО РАСПОЛОЖЕНИЯ!")]
        [StringLength(42, MinimumLength = 1, ErrorMessage = "Диапазон символов : 1-42")]
        public string location { get; set; }

        [Required(ErrorMessage = "УКАЖИТЕ ОСНОВНУЮ ИНФОРМАЦИЮ!")]
        [StringLength(42, MinimumLength = 1, ErrorMessage = "Диапазон символов : 1-499")]
        public string info { get; set; }
    }
}
