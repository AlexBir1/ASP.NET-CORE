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
    public class CafeEmployeesService : ICafeEmployeesService
    {
        private readonly Cafe_employeesRepository CafeEmployeesRepository;

        public CafeEmployeesService(Cafe_employeesRepository _Cafe_employeesRepository)
        {
            CafeEmployeesRepository = _Cafe_employeesRepository;
        }

        public IBaseResponse<Cafe_employeesViewModel> CreateCafeEmployee(Cafe_employeesViewModel cafe_Employees)
        {
            var BaseRes = new DBResponse<Cafe_employeesViewModel>();
            try
            {
                CafeEmployeesRepository.Create(cafe_Employees);
                var new_cafe_Employees = CafeEmployeesRepository
                    .GetAll()
                    .FirstOrDefault(ce=>ce.phone == cafe_Employees.phone);

                if (new_cafe_Employees != null)
                {
                    BaseRes.Description = "ДОБАВЛЕНИЕ РАБОТНИКА УСПЕШНО!";
                    BaseRes.Data = new_cafe_Employees;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }

                BaseRes.Description = "ОШИБКА ДОБАВЛЕНИЯ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<Cafe_employeesViewModel>
                {
                    Description = $"[CreateCafe_employees] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Cafe_employeesViewModel> DeleteCafeEmployee(Cafe_employeesViewModel cafe_Employees)
        {
            try
            {
                CafeEmployeesRepository.Delete(cafe_Employees);
                var new_cafe_Employees = CafeEmployeesRepository
                    .GetAll()
                    .FirstOrDefault(ce => ce.id == cafe_Employees.id);
                if (new_cafe_Employees == null)
                {
                    return new DBResponse<Cafe_employeesViewModel>()
                    {
                        Description = "УДАЛЕНИЕ РАБОТНИКА КАФЕ УСПЕШНО!",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Cafe_employeesViewModel>()
                {
                    Description = "ОШИБКА УДАЛЕНИЯ РАБОТНИКА КАФЕ!",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Cafe_employeesViewModel>()
                {
                    Description = $"[DeleteCafeEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Cafe_employeesViewModel> EditCafeEmployee(Cafe_employeesViewModel cafe_Employees)
        {
            try
            {
                CafeEmployeesRepository.Edit(cafe_Employees, cafe_Employees.id);
                var new_cafe_Employees = CafeEmployeesRepository
                    .GetAll()
                    .FirstOrDefault(ce => ce.id == cafe_Employees.id);
                if (new_cafe_Employees == cafe_Employees)
                {
                    return new DBResponse<Cafe_employeesViewModel>()
                    {
                        Description = "ИЗМЕНЕНИЕ ДАННЫХ ПОЛЬЗОВАТЕЛЯ УСПЕШНО!",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Cafe_employeesViewModel>()
                {
                    Description = "ОШИБКА РЕДАКТИРОВАНИЯ ДАННЫХ ПОЛЬЗОВАТЕЛЯ!",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Cafe_employeesViewModel>()
                {
                    Description = $"[EditCafeEmployee] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<Cafe_employeesViewModel>> GetCafeEmployees()
        {
            try
            {
                var cafe_employees = CafeEmployeesRepository.GetAll();
                if (cafe_employees.Count() != 0)
                {
                    return new DBResponse<IEnumerable<Cafe_employeesViewModel>>()
                    {
                        Data = cafe_employees,
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<Cafe_employeesViewModel>>()
                {
                    Description = "Список пуст!",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Cafe_employeesViewModel>>()
                {
                    Description = $"[GetCafeEmployees] : {ex.Message}"
                };
            }
        }
        public IBaseResponse<ClaimsIdentity> Log_in(LoginViewModel _employee)
        {
            var user = CafeEmployeesRepository.GetAll().FirstOrDefault(c => c.login == _employee.login);
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
                var Response = CafeEmployeeAuthenticate(user);
                return new DBResponse<ClaimsIdentity>
                {
                    Data = Response,
                    StatusCode = StatusCode.OK,
                    Description = "Вход разрешен!"
                };
            }

        }
        public IBaseResponse<ClaimsIdentity> Register(CERegisterViewModel _employee)
        {
            var user = CafeEmployeesRepository.GetAll().FirstOrDefault(c => c.login == _employee.login);

            if (user != null)
            {
                return new DBResponse<ClaimsIdentity>
                {
                    Description = "Пользователь с этим логином уже существует!",
                    StatusCode = StatusCode.RegisterErr
                };
            }

            var cEmployee = new Cafe_employeesViewModel
            {
                id = _employee.id,
                cafe_name = _employee.cafe_name,
                fullname = _employee.fullname,
                login = _employee.login,
                password = _employee.password,
                phone = _employee.phone,
                rank = _employee.rank,
                status = UserStatus.employee
            };

            CafeEmployeesRepository.Create(cEmployee);
            cEmployee = CafeEmployeesRepository.GetAll().FirstOrDefault(c => c.login == _employee.login);
            var Response = CafeEmployeeAuthenticate(cEmployee);

            return new DBResponse<ClaimsIdentity>
            {
                Data = Response,
                StatusCode = StatusCode.OK,
                Description = "Вход разрешен!"
            };
        }

        private ClaimsIdentity CafeEmployeeAuthenticate(Cafe_employeesViewModel _employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _employee.login),
                new Claim(ClaimTypes.Email, _employee.login),
                new Claim(ClaimTypes.MobilePhone, _employee.phone),
                new Claim(ClaimTypes.UserData, _employee.cafe_name),
                new Claim(ClaimTypes.Sid,_employee.id.ToString()),
                new Claim(ClaimTypes.Role,_employee.rank.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, _employee.status.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
