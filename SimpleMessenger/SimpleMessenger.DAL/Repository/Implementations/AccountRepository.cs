
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleMessenger.DAL.Repository.Interfaces;
using SimpleMessenger.DAL.Response;
using SimpleMessenger.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessenger.DAL.Repository.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDBContext _db;
        private readonly UserManager<Account> _UserManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<Account> userManager, SignInManager<Account> signInManager, AppDBContext db, IConfiguration configuration)
        {
            _UserManager = userManager;
            _signInManager = signInManager;
            _db = db;
            _configuration = configuration;
        }

        public async Task<IBaseResponse<Account>> AccountSignInAsync(Account account, string _password)
        {
            var Result = await _signInManager.PasswordSignInAsync(account, _password, false, false);

            if (!Result.Succeeded)
            {
                List<string> ErrorList = new List<string>();
                ErrorList.Add("Something went wrong. Try again.");
                return new BaseResponse<Account>
                {
                    IsSucceeded = false,
                    Errors = ErrorList
                };
            }

            var userClaims = await _UserManager.GetClaimsAsync(account);
            var claims = userClaims.ToList();

            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Today.AddDays(7), signingCredentials: new SigningCredentials
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTClientSecret"])), SecurityAlgorithms.HmacSha256));

            return new BaseResponse<Account>
            {
                IsSucceeded = true,
                Data = account,
                userToken = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<IBaseResponse<Account>> AccountSignOutAsync()
        {
            await _signInManager.SignOutAsync();
            return new BaseResponse<Account>
            {
                IsSucceeded = true,
                Data = null
            };
        }

        public async Task<IBaseResponse<Account>> CreateAccountAsync(Account _newAccount, string _newPassword)
        {
            try
            {
                var AccountCreated = await _UserManager.CreateAsync(_newAccount, _newPassword);

                if (!AccountCreated.Succeeded)
                {
                    List<string> ErrorList = new List<string>();
                    foreach(var i in AccountCreated.Errors)
                    {
                        ErrorList.Add(i.Description);
                    }
                    return new BaseResponse<Account>
                    {
                        IsSucceeded = false,
                        Errors = ErrorList
                    };
                }

                var Result = await _signInManager.PasswordSignInAsync(_newAccount, _newPassword, false, false);

                Claim[] uClaims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,_newAccount.Id),
                    new Claim(ClaimTypes.Name,_newAccount.UserName),
                    new Claim(ClaimTypes.Email,_newAccount.Email),
                };

                await _UserManager.AddClaimsAsync(_newAccount,uClaims);

                var token = new JwtSecurityToken(claims: uClaims, expires: DateTime.Today.AddDays(7), signingCredentials: new SigningCredentials
                    (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTClientSecret"])), SecurityAlgorithms.HmacSha256));

                if (!Result.Succeeded)
                {
                    return new BaseResponse<Account>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { new string("Something went wrong. Try again.") }
                    };
                }

                return new BaseResponse<Account>
                {
                    IsSucceeded = true,
                    Data = _newAccount,
                    userToken = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Account>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<Account>> GetAccountAsync(string _userId = null, string _userEmail = null, string _username = null)
        {
            try
            {
                Account retrievedAccount = new();

                if (_userEmail is not null)
                    retrievedAccount = await _UserManager.FindByEmailAsync(_userEmail);

                else if (_username is not null)
                    retrievedAccount = await _UserManager.FindByNameAsync(_username);

                else if(_userId is null)
                    return new BaseResponse<Account>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { new string("There was no specified parameter") }
                    };

                else
                    retrievedAccount = await _UserManager.FindByIdAsync(_userId);

                if(retrievedAccount is null)
                    return new BaseResponse<Account>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { new string("Account doesn`t exist") }
                    };

                return new BaseResponse<Account>
                {
                    IsSucceeded = true,
                    Data = retrievedAccount
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Account>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Account>>> GetAccountsAsync()
        {
            try
            {
                var retrievedAccounts = await _UserManager.Users.ToListAsync();

                if(retrievedAccounts is null || retrievedAccounts.Count == 0)
                    return new BaseResponse<IEnumerable<Account>>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { new string("Account`s list is empty") }
                    };
                return new BaseResponse<IEnumerable<Account>>
                {
                    IsSucceeded = true,
                    Data = retrievedAccounts
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Account>>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Account>>> GetAccountsAsync(string _userId)
        {
            try
            {
                var retrievedAccounts = await _UserManager.Users.Where(x=>x.Id != _userId).ToListAsync();

                if (retrievedAccounts is null || retrievedAccounts.Count == 0)
                    return new BaseResponse<IEnumerable<Account>>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { new string("Account`s list is empty") }
                    };
                return new BaseResponse<IEnumerable<Account>>
                {
                    IsSucceeded = true,
                    Data = retrievedAccounts
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Account>>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }

        public async Task<IBaseResponse<Account>> RemoveAccountAsync(string _userId)
        {
            try
            {
                var retrievedAccount = await _UserManager.FindByIdAsync(_userId);

                if(retrievedAccount is null)
                    return new BaseResponse<Account>
                    {
                        IsSucceeded = false,
                        Errors = new List<string> { "Account doesn`t exist" }
                    };

                var Result = _db.Users.Remove(retrievedAccount);
                await _db.SaveChangesAsync();

                return new BaseResponse<Account>
                {
                    IsSucceeded = true,
                    Data = retrievedAccount
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Account>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }

        }

        public async Task<IBaseResponse<Account>> UpdateAccountAsync(Account _account, string _oldPassword, string _newPassword)
        {
            try
            {
                Account updatedAccount = new();

                if (_oldPassword is not null)
                {
                    bool IsPasswordCorrect = await _UserManager.CheckPasswordAsync(_account, _oldPassword);

                    if (!IsPasswordCorrect)
                    {
                        return new BaseResponse<Account>
                        {
                            IsSucceeded = false,
                            Errors = new List<string> { new string("Incorrect old password") }
                        };
                    }

                    if (_newPassword is not null)
                    {
                        var AccountPasswordUpdateResult = await _UserManager.ChangePasswordAsync(_account, _oldPassword, _newPassword);
                        var AccountUpdateResult = await _UserManager.UpdateAsync(_account);

                        updatedAccount = await _UserManager.FindByIdAsync(_account.Id);

                        return new BaseResponse<Account>
                        {
                            IsSucceeded = true,
                            Data = updatedAccount
                        };
                    }

                    var AccountPasswordRemoveResult = await _UserManager.RemovePasswordAsync(_account);
                    var accountUpdateResult = await _UserManager.UpdateAsync(_account);

                    updatedAccount = await _UserManager.FindByIdAsync(_account.Id);

                    return new BaseResponse<Account>
                    {
                        IsSucceeded = true,
                        Data = updatedAccount
                    };
                }

                var Result = await _UserManager.UpdateAsync(_account);

                updatedAccount = await _UserManager.FindByIdAsync(_account.Id);

                return new BaseResponse<Account>
                {
                    IsSucceeded = true,
                    Data = updatedAccount
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Account>
                {
                    IsSucceeded = false,
                    Errors = new List<string> { new string(ex.Message) }
                };
            }
        }
    }
}
