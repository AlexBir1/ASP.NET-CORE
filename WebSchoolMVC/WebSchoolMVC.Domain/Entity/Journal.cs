using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolMVC.Domain.Entity
{
    public class Journal
    {
        public int Id { get; set; }
        public int Student_Id { get; set; }
        public int Subject_Id { get; set; }
        public int Mark { get; set; }
        public DateTime MarkingDate { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
