using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Repositories;
using WebHostel.Domain.Enum;
using WebHostel.Domain.Response;
using WebHostel.Models;
using WebHostel.Services.Interfaces;

namespace WebHostel.Services.Implements
{
    public class EmployeeSpendsService : IEmployeeSpendsService
    {
        private readonly Employee_spendsRepository EmployeeSpendsS;

        public EmployeeSpendsService(Employee_spendsRepository _EmployeeSpends)
        {
            EmployeeSpendsS = _EmployeeSpends;
        }

        public IBaseResponse<Employee_spendsViewModel> 
            CreateEmployeeSpends(Employee_spendsViewModel employee_Spends)
        {
            try
            {
                EmployeeSpendsS.Create(employee_Spends);
                if (EmployeeSpendsS.GetAll()
                    .FirstOrDefault(es => es.employee_phone == employee_Spends.employee_phone
                    && es.periodStart_date == employee_Spends.periodStart_date) != null)
                {
                    return new DBResponse<Employee_spendsViewModel>
                    {
                        Description = "Обьект добавился",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Employee_spendsViewModel>
                {
                    Description = "Ошибка",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch(Exception ex)
            {
                return new DBResponse<Employee_spendsViewModel>
                {
                    Description = $"[CreateEmployeeSpends] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Employee_spendsViewModel> 
            DeleteEmployeeSpends(Employee_spendsViewModel employee_Spends)
        {
            try
            {
                EmployeeSpendsS.Delete(employee_Spends);
                if (EmployeeSpendsS.GetAll()
                    .FirstOrDefault(es => es.id == employee_Spends.id) == null)
                {
                    return new DBResponse<Employee_spendsViewModel>
                    {
                        Description = "Обьект удалился",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Employee_spendsViewModel>
                {
                    Description = "Ошибка",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Employee_spendsViewModel>
                {
                    Description = $"[DeleteEmployeeSpends] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<Employee_spendsViewModel> 
            EditEmployeeSpends(Employee_spendsViewModel employee_Spends)
        {
            try
            {
                EmployeeSpendsS.Edit(employee_Spends, employee_Spends.id);
                if (EmployeeSpendsS.GetAll()
                    .FirstOrDefault(es => es.id == employee_Spends.id) == employee_Spends)
                {
                    return new DBResponse<Employee_spendsViewModel>
                    {
                        Description = "Обьект изменился",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<Employee_spendsViewModel>
                {
                    Description = "Ошибка",
                    StatusCode = StatusCode.InternalServiceError
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<Employee_spendsViewModel>
                {
                    Description = $"[CreateEmployeeSpends] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<Employee_spendsViewModel>> GetEmployeeSpends()
        {
            try
            {
                var _employee_spends = EmployeeSpendsS.GetAll();
                if (_employee_spends.Count() !=0)
                {
                    return new DBResponse<IEnumerable<Employee_spendsViewModel>>
                    {
                        Data = _employee_spends,
                        Description = "Успешно",
                        StatusCode = StatusCode.OK
                    };
                }
                return new DBResponse<IEnumerable<Employee_spendsViewModel>>
                {
                    Description = "Список пуст",
                    StatusCode = StatusCode.NotFound
                };
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<Employee_spendsViewModel>>
                {
                    Description = $"[GetEmployeeSpends] : {ex.Message}"
                };
            }
        }
    }
}
