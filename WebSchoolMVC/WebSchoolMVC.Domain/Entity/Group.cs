using System.Collections.Generic;

namespace WebSchoolMVC.Domain.Entity
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int? Teacher_Id { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Timetable> Timetables { get; set; }
    }
}