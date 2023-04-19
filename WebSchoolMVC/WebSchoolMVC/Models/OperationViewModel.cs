using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchoolMVC.Models
{
    public class OperationViewModel
    {
        public OperationStatus Status { get; set; }
        public string Message { get; set; }
        public string RedirectLink { get; set; }
        public Dictionary<string, string> FieldsAndValues { get; set; }
    }
    public enum OperationStatus
    {
        Succeeded,
        Failed
    }
}
