using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSchoolMVC.Domain.Response
{
    public class DBResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public string Description { get; set; }
    }

    public interface IBaseResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public string Description { get; set; }
    }
}
