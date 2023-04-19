using System.Collections.Generic;
using System.Threading.Tasks;
using WebSchoolMVC.Domain.Response;

namespace WebSchoolMVC.DataAccess
{
    public interface IBaseInterface<T>
    {
        Task<IBaseResponse<T>> Create(T EntityToCreate);
        Task<IBaseResponse<T>> Delete(T EntityToDelete);
        Task<IBaseResponse<T>> Edit(T EntityToEdit);
        Task<IBaseResponse<IEnumerable<T>>> GetAll();
        Task<IBaseResponse<T>> GetById(int Id);
    }
}
