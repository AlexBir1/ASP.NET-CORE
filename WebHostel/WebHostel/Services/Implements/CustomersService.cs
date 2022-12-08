using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Implements
{
    public class CustomersService : ICustomersService
    {
        private readonly CustomersRepository CustomersRepository;

        public CustomersService(CustomersRepository _CustomersRepository)
        {
            CustomersRepository = _CustomersRepository;
        }

        public IBaseResponse<CustomersViewModel> CreateCustomers(CustomersViewModel _Customers)
        {
            var BaseRes = new DBResponse<CustomersViewModel>();
            try
            {
                CustomersRepository.Create(_Customers);
                var new_Customers = CustomersRepository.GetAll()
                    .FirstOrDefault(c=>c.phone==_Customers.phone);
                if (new_Customers != null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CustomersViewModel>
                {
                    Description = $"[CreateCustomers] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CustomersViewModel> DeleteCustomers(CustomersViewModel _Customers)
        {
            var BaseRes = new DBResponse<CustomersViewModel>();
            try
            {
                CustomersRepository.Delete(_Customers);
                var new_Customers = CustomersRepository.GetAll()
                    .FirstOrDefault(c => c.phone == _Customers.phone);
                if (new_Customers == null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "УДАЛЕНИЕ КЛИЕНТА УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА УДАЛЕНИЯ КЛИЕНТА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CustomersViewModel>
                {
                    Description = $"[DeleteCustomers] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<CustomersViewModel> EditCustomers(CustomersViewModel _Customers)
        {
            var BaseRes = new DBResponse<CustomersViewModel>();
            try
            {
                CustomersRepository.Edit(_Customers, _Customers.id);
                var new_hostel = CustomersRepository.GetAll()
                    .FirstOrDefault(c => c.id == _Customers.id);
                if (new_hostel != null)
                {
                    BaseRes.StatusCode = StatusCode.OK;
                    BaseRes.Description = "ОБНОВЛЕНИЕ ДАННЫХ УСПЕШНО!";
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА ОБНОВЛЕНИЯ ДАННЫХ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CustomersViewModel>
                {
                    Description = $"[EditCustomers] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<CustomersViewModel> GetCustomers(string Customers_name)
        {
            var BaseRes = new DBResponse<CustomersViewModel>();
            try
            {
                var Customers = CustomersRepository.Get(Customers_name);
                if (Customers != null)
                {
                    BaseRes.Data = Customers;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<CustomersViewModel>
                {
                    Description = $"[GetCustomers] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<CustomersViewModel>> GetCustomerss()
        {
            var BaseRes = new DBResponse<IEnumerable<CustomersViewModel>>();
            try
            {
                var Customerss = CustomersRepository.GetAll();
                if (Customerss.Count() != 0)
                {
                    BaseRes.Data = Customerss;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<CustomersViewModel>>
                {
                    Description = $"[GetCustomerss] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<ClaimsIdentity> Log_in(LoginViewModel _customer)
        {
            var user = CustomersRepository.GetAll().FirstOrDefault(c => c.login == _customer.login);
            if (user == null)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Пользователь не существует!",
                    StatusCode = StatusCode.LoginErr
                };
            }
            else if (_customer.password != user.password)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Неверный логин или пароль!",
                    StatusCode = StatusCode.LoginErr
                };
            }
            else
            {
                var Response = CustomerAuthenticate(user);
                return new DBResponse<ClaimsIdentity>
                {
                    Data = Response,
                    StatusCode = StatusCode.OK,
                    Description = "Вход разрешен!"
                };
            }
            
        }
        public IBaseResponse<ClaimsIdentity> Register(CRegisterViewModel _customer)
        {
            var user = CustomersRepository.GetAll().FirstOrDefault(c => c.login == _customer.login);
            
            if (user != null)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Пользователь с этим логином уже существует!",
                    StatusCode = StatusCode.RegisterErr
                };
            }

            var Customer = new CustomersViewModel
            {
                id = _customer.id,
                fullname = _customer.fullname,
                hostel_name = _customer.hostel_name,
                login = _customer.login,
                password = _customer.password,
                phone = _customer.phone,
                status = UserStatus.customer
            };
            try
            {
                CustomersRepository.Create(Customer);
                var User = CustomersRepository.GetAll().FirstOrDefault(c => c.login == _customer.login);
                var Response = CustomerAuthenticate(User);

                return new DBResponse<ClaimsIdentity>
                {
                    Data = Response,
                    StatusCode = StatusCode.OK,
                    Description = "Вход разрешен!"
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    StatusCode = StatusCode.InternalServiceError,
                    Description = $"[Register]: {ex.Message}"
                };
            }
        }
        private ClaimsIdentity CustomerAuthenticate(CustomersViewModel _customer)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _customer.login),
                new Claim(ClaimTypes.Email, _customer.login),
                new Claim(ClaimTypes.MobilePhone, _customer.phone),
                new Claim(ClaimTypes.UserData, _customer.hostel_name),
                new Claim(ClaimTypes.Sid,_customer.id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, _customer.status.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
