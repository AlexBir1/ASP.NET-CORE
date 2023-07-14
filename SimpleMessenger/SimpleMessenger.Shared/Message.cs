using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.Shared
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Account_Nickname { get; set; }

        [Required]
        public string MessageText { get; set; }

        [Required]
        public DateTime Date { get; set; } 

        public int Chat_Id { get; set; }

        public Chat Chat { get; set; }
    }
}
