using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBSHOP.DAL
{
    public interface IBaseInterface<T>
    {
        bool Create(T Entity);
        bool Delete(T Entity);
        bool Edit(T Entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int Id);
    }
}
