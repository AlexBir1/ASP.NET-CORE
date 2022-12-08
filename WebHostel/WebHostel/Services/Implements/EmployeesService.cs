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
    public class EmployeesService : IEmployeesService
    {
        private readonly EmployeesRepository employeesRepository;

        public EmployeesService(EmployeesRepository _employeesRepository)
        {
            employeesRepository = _employeesRepository;
        }

        public IBaseResponse<EmployeesViewModel> CreateEmployee(EmployeesViewModel employee)
        {
            try
            {
                employeesRepository.Create(employee);
                if (employeesRepository.GetAll()
                    .FirstOrDefault(e => e.phone == employee.phone) != null)
                {
                    return new DBResponse<EmployeesViewModel>
                    {
                        Description = "Объект добавился",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<EmployeesViewModel>
                {
                    Description = "Ошибка",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<EmployeesViewModel>
                {
                    Description = $"[CreateEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<EmployeesViewModel> DeleteEmployee(EmployeesViewModel employee)
        {
            try
            {
                employeesRepository.Delete(employee);
                if (employeesRepository.GetAll()
                    .FirstOrDefault(e => e.id == employee.id) == null)
                {
                    return new DBResponse<EmployeesViewModel>
                    {
                        Description = "Объект удалился",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<EmployeesViewModel>
                {
                    Description = "Ошибка",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<EmployeesViewModel>
                {
                    Description = $"[DeleteEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<EmployeesViewModel> EditEmployee(EmployeesViewModel employee)
        {
            try
            {
                employeesRepository.Edit(employee, employee.id);
                if (employeesRepository.GetAll()
                    .FirstOrDefault(e => e.id == employee.id) == employee)
                {
                    return new DBResponse<EmployeesViewModel>
                    {
                        Description = "Объект изменился",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<EmployeesViewModel>
                {
                    Description = "Ошибка",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<EmployeesViewModel>
                {
                    Description = $"[CreateEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<EmployeesViewModel>> GetEmployees()
        {
            try
            {
                var employees = employeesRepository.GetAll();
                if (employees.Count() != 0)
                {
                    return new DBResponse<IEnumerable<EmployeesViewModel>>
                    {
                        Data = employees,
                        Description = "Найдено",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<EmployeesViewModel>>
                {
                    Description = "Ошибка",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<EmployeesViewModel>>
                {
                    Description = $"[CreateEmployee] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<ClaimsIdentity> Log_in(LoginViewModel _employee)
        {
            var user = employeesRepository.GetAll()
                .FirstOrDefault(c => c.login == _employee.login);
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
                var Response = EmployeeAuthenticate(user);
                return new DBResponse<ClaimsIdentity>
                {
                    Data = Response,
                    StatusCode = StatusCode.OK,
                    Description = "Вход разрешен!"
                };
            }

        }
        public IBaseResponse<ClaimsIdentity> Register(ERegisterViewModel _employee)
        {
            var user = employeesRepository.GetAll().FirstOrDefault(c => c.login == _employee.login);

            if (user != null)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Пользователь с этим логином уже существует!",
                    StatusCode = StatusCode.RegisterErr
                };
            }

            var Employee = new EmployeesViewModel
            {
                id = _employee.id,
                fullname = _employee.fullname,
                hostel_name = _employee.hostel_name,
                login = _employee.login,
                password = _employee.password,
                phone = _employee.phone,
                rank = _employee.rank,
                status = UserStatus.employee
            };

            employeesRepository.Create(Employee);
            var User = employeesRepository.GetAll().FirstOrDefault(c => c.login == Employee.login);
            var Response = EmployeeAuthenticate(User);

            return new DBResponse<ClaimsIdentity>
            {
                Data = Response,
                StatusCode = StatusCode.OK,
                Description = "Вход разрешен!"
            };
        }

        private ClaimsIdentity EmployeeAuthenticate(EmployeesViewModel _employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _employee.login),
                new Claim(ClaimTypes.Email, _employee.login),
                new Claim(ClaimTypes.MobilePhone, _employee.phone),
                new Claim(ClaimTypes.UserData, _employee.hostel_name),
                new Claim(ClaimTypes.Sid,_employee.id.ToString()),
                new Claim(ClaimTypes.Role,_employee.rank.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, _employee.status.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
