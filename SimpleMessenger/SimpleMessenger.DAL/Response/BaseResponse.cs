using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.DAL.Response
{
    public class BaseResponse<T>:IBaseResponse<T>
    {
        public T Data { get; set; }
        public bool IsSucceeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string userToken { get; set; }
    }
}
