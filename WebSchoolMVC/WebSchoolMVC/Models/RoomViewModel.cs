using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolMVC.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Number is empty")]
        [MinLength(1, ErrorMessage = "Fullname must be at least 1 charater")]
        [MaxLength(5, ErrorMessage = "Fullname must be no longer than 5 characters")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Floor is empty")]
        public int? Floor { get; set; }

        public int? Teacher_Id { get; set; }

        public SelectList Teachers { get; set; }
    }
}
