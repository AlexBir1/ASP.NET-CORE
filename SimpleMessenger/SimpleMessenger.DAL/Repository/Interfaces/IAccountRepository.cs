using SimpleMessenger.DAL.Response;
using SimpleMessenger.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.DAL.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task<IBaseResponse<Account>> CreateAccountAsync(Account _newAccount, string _newPassword);
        Task<IBaseResponse<Account>> UpdateAccountAsync(Account _account, string _oldPassword, string _newPassword);
        Task<IBaseResponse<Account>> RemoveAccountAsync(string _userId);
        Task<IBaseResponse<Account>> GetAccountAsync(string _userId = null, string _userEmail = null, string _username = null);
        Task<IBaseResponse<IEnumerable<Account>>> GetAccountsAsync();
        Task<IBaseResponse<IEnumerable<Account>>> GetAccountsAsync(string _userId);
        Task<IBaseResponse<Account>> AccountSignInAsync(Account account, string _password);
        Task<IBaseResponse<Account>> AccountSignOutAsync();
    }
}
