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
    public class WirehouseEmployeesService : IWirehouseEmployeesService
    {
        private readonly Wirehouse_employeesRepository wirehouse_Employees;

        public WirehouseEmployeesService(Wirehouse_employeesRepository _wirehouse_Employees)
        {
            wirehouse_Employees = _wirehouse_Employees;
        }

        public IBaseResponse<Wirehouse_employeesViewModel> 
            CreateWEmployee(Wirehouse_employeesViewModel wirehouse_Employee)
        {
            try
            {
                wirehouse_Employees.Create(wirehouse_Employee);
                if (wirehouse_Employees.GetAll()
                    .FirstOrDefault(we=>we.phone == wirehouse_Employee.phone) != null)
                {
                    return new DBResponse<Wirehouse_employeesViewModel>
                    {
                        Description = "inserted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Wirehouse_employeesViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<Wirehouse_employeesViewModel>
                {
                    Description = $"[CreateWEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Wirehouse_employeesViewModel> 
            DeleteWEmployee(Wirehouse_employeesViewModel wirehouse_Employee)
        {
            try
            {
                wirehouse_Employees.Delete(wirehouse_Employee);
                if (wirehouse_Employees.GetAll()
                    .FirstOrDefault(we => we.id == wirehouse_Employee.id) == null)
                {
                    return new DBResponse<Wirehouse_employeesViewModel>
                    {
                        Description = "deleted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Wirehouse_employeesViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Wirehouse_employeesViewModel>
                {
                    Description = $"[DeleteWEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Wirehouse_employeesViewModel> 
            EditWEmployee(Wirehouse_employeesViewModel wirehouse_Employee)
        {
            try
            {
                wirehouse_Employees.Edit(wirehouse_Employee, wirehouse_Employee.id);
                if (wirehouse_Employees.GetAll()
                    .FirstOrDefault(we => we.id == wirehouse_Employee.id) == wirehouse_Employee)
                {
                    return new DBResponse<Wirehouse_employeesViewModel>
                    {
                        Description = "deleted",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Wirehouse_employeesViewModel>
                {
                    Description = "err",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Wirehouse_employeesViewModel>
                {
                    Description = $"[EditWEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<Wirehouse_employeesViewModel>> GetWEmployees()
        {
            try
            {
                var _wirehouse_Employees = wirehouse_Employees.GetAll();
                if (_wirehouse_Employees.Count() != 0)
                {
                    return new DBResponse<IEnumerable<Wirehouse_employeesViewModel>>
                    {
                        Data = _wirehouse_Employees,
                        Description = "found",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<Wirehouse_employeesViewModel>>
                {
                    Description = "not found any",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Wirehouse_employeesViewModel>>
                {
                    Description = $"[GetWEmployees] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<ClaimsIdentity> Log_in(LoginViewModel _employee)
        {
            var user = wirehouse_Employees.GetAll().FirstOrDefault(c => c.login == _employee.login);
            if (user == null)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Пользователь не существует!",
                    StatusCode = StatusCode.LoginErr
                };
            }
            else if (_employee.password != user.password)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Неверный логин или пароль!",
                    StatusCode = StatusCode.LoginErr
                };
            }
            else
            {
                var Response = WEmployeeAuthenticate(user);
                return new DBResponse<ClaimsIdentity>
                {
                    Data = Response,
                    StatusCode = StatusCode.OK,
                    Description = "Вход разрешен!"
                };
            }

        }
        public IBaseResponse<ClaimsIdentity> Register(WERegisterViewModel _employee)
        {
            var user = wirehouse_Employees.GetAll().FirstOrDefault(c => c.login == _employee.login);

            if (user != null)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Пользователь с этим логином уже существует!",
                    StatusCode = StatusCode.RegisterErr
                };
            }

            var WEmployee = new Wirehouse_employeesViewModel
            {
                id = _employee.id,
                fullname =_employee.fullname,
                login = _employee.login,
                password = _employee.password,
                phone = _employee.phone,
                rank = _employee.rank,
                wirehouse_name = _employee.wirehouse_name,
                status = UserStatus.employee
            };

            wirehouse_Employees.Create(WEmployee);
            var User = wirehouse_Employees.GetAll().FirstOrDefault(c => c.login == _employee.login);
            var Response = WEmployeeAuthenticate(User);

            return new DBResponse<ClaimsIdentity>
            {
                Data = Response,
                StatusCode = StatusCode.OK,
                Description = "Вход разрешен!"
            };
        }

        private ClaimsIdentity WEmployeeAuthenticate(Wirehouse_employeesViewModel _employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _employee.login),
                new Claim(ClaimTypes.Email, _employee.login),
                new Claim(ClaimTypes.MobilePhone, _employee.phone),
                new Claim(ClaimTypes.UserData, _employee.wirehouse_name),
                new Claim(ClaimTypes.Sid,_employee.id.ToString()),
                new Claim(ClaimTypes.Role,_employee.rank.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, _employee.status.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
