using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolMVC.Domain.Enum
{
    public enum StudentOrderBy
    {
        [Display(Name = "None")]
        NoOrderBy,
        [Display(Name = "Fullname(A-Z)")]
        FullnameAsc,
        [Display(Name = "Fullname(Z-A)")]
        FullnameDesc,
        [Display(Name = "Group(A-Z)")]
        GroupAsc,
        [Display(Name = "Group(Z-A)")]
        GroupDesc
    }
}
