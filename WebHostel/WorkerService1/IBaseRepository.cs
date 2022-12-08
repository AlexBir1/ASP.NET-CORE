using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerService1
{
    public interface IBaseRepository <T>
    {
        bool Create(T Entity);
        T Get(string unique_value);
        T Get(string unique_value, string _hostel_name);
        IEnumerable<T> GetAll();
        int GetID(string unique_value);
        bool Delete(T Entity);
        bool Edit(T Entity, int id);
    }
}
