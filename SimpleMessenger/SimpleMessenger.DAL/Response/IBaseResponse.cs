using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.DAL.Response
{
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        string userToken { get; set; }
        bool IsSucceeded { get; set; }
        IEnumerable<string> Errors { get; set; }
    }
}
