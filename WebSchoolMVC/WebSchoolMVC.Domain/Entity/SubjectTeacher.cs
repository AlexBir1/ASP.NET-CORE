using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolMVC.Domain.Entity
{
    public class SubjectTeacher
    {
        public int Teacher_Id { get; set; }
        public int Subject_Id { get; set; }

        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
    }
}
