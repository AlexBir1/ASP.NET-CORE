using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Enum;

namespace WebHostel.Domain.Response
{
    public class DBResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }

    }

    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        StatusCode StatusCode { get; set; }
        string Description { get; set; }
    }
}
