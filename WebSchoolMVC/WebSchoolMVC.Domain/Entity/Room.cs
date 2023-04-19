using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolMVC.Domain.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int Floor { get; set; }
        public int? Teacher_Id { get; set; }

        public Teacher Teacher { get; set; }
        public ICollection<Timetable> Timetables { get; set; }
    }
}
