using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolMVC.Domain.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int Group_Id { get; set; }

        public Group Group { get; set; }
        public ICollection<Journal> Marks { get; set; }
    }
}
