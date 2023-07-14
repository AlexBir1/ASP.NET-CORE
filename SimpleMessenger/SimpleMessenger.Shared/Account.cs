using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleMessenger.Shared
{
    public class Account : IdentityUser
    {
        [Required]
        public string Nickname { get; set; }
    }
}
