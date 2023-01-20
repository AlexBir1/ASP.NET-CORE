using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elfbar_shop.Domain.Response
{
    public class DBResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCodes StatusCode { get; set; }
        public T Data { get; set; }

    }

    public interface IBaseResponse<T>
    {
        T Data { get; set; }
        StatusCodes StatusCode { get; set; }
        string Description { get; set; }
    }
}
