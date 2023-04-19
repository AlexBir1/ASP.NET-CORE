using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolMVC.Models
{
    public class TimetableViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fullname is empty")]
        [MinLength(1, ErrorMessage = "Fullname must be at least 1 charater")]
        [MaxLength(45, ErrorMessage = "Fullname must not be longer than 45 characters")]
        public string Topic { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        [Required(ErrorMessage = "Subject ID is empty")]
        public int Subject_Id { get; set; }

        [Required(ErrorMessage = "Group ID is empty")]
        public int Group_Id { get; set; }

        [Required(ErrorMessage = "Room ID is empty")]
        public int Room_Id { get; set; }

        public SelectList RoomSelectList { get; set; }
        public SelectList GroupSelectList { get; set; }
        public SelectList SubjectSelectList { get; set; }
    }
}
