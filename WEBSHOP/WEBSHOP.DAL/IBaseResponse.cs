using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.DAL.Repositories
{
    public class DBResponse<T> : IBaseResponse<T>
    {
        public string Msg { get; set; }
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        string Msg { get; set; }
    }
}
