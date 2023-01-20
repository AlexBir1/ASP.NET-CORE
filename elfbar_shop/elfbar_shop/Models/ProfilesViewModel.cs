﻿using elfbar_shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Models
{
    public class ProfilesViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public string alias { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public string login { get; set; }

        [Required(ErrorMessage = "ПОЛЕ ПУСТЕ")]
        public string passw { get; set; }
    }
}
