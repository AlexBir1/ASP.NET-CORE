using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolMVC.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fullname is empty")]
        [MinLength(1, ErrorMessage = "Fullname must be at least 1 charaters")]
        [MaxLength(15, ErrorMessage = "Fullname must not be longer than 15 characters")]
        public string Title { get; set; }

        public int? Teacher_Id { get; set; }
    }
}
