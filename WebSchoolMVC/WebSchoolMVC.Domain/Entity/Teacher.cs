using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebSchoolMVC.Domain.Entity
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }

        public Group GroupUnderLeading { get; set; }

        public Room Room { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<SubjectTeacher> TeacherHasSubjects { get; set; }
    }
}