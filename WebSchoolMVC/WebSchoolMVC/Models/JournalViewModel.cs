using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebSchoolMVC.Domain.Entity;

namespace WebSchoolMVC.Models
{
    public class JournalViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        public int Student_Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        public int Subject_Id { get; set; }

        [Required(ErrorMessage = "The field is required.")]
        public int Mark { get; set; }

        public DateTime MarkingDate { get; set; }

        public SelectList Subjects { get; set; }
        public List<Student> Students { get; set; }
    }
}
