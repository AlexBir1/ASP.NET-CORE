using System.Collections.Generic;

namespace WebSchoolMVC.Domain.Entity
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Journal> Marks { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Timetable> Timetables { get; set; }
        public ICollection<SubjectTeacher> SubjectHasTeachers { get; set; }
    }
}