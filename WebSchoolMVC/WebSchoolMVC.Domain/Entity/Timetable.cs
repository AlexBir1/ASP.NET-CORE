using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolMVC.Domain.Entity
{
    public class Timetable
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int Subject_Id { get; set; }
        public int Group_Id { get; set; }
        public int Room_Id { get; set; }

        public Room Room { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
    }
}
