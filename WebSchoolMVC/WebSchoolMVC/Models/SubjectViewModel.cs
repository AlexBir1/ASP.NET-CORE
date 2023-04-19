using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolMVC.Models
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is empty")]
        [MinLength(1, ErrorMessage = "Title must be at least 1 charater")]
        [MaxLength(45, ErrorMessage = "Title must not be longer than 45 characters")]
        public string Title { get; set; }
    }
}
