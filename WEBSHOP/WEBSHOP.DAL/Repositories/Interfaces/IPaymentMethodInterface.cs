using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBSHOP.Domain.ViewModels;

namespace WEBSHOP.DAL.Repositories.Interfaces
{
    public interface IPaymentMethodInterface : IBaseInterface<PaymentMethodViewModel>
    {
        Task<IEnumerable<PaymentMethodViewModel>> GetByUserId(int Id);
    }
}
