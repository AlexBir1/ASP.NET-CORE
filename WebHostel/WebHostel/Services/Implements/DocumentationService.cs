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
    public class DocumentationService : IDocumentationService
    {
        private readonly DocumentationRepository DocumentationRepository;

        public DocumentationService(DocumentationRepository _DocumentationRepository)
        {
            DocumentationRepository = _DocumentationRepository;
        }

        public IBaseResponse<DocumentationViewModel> CreateDocumentation(DocumentationViewModel _Documentation)
        {
            var BaseRes = new DBResponse<DocumentationViewModel>();
            try
            {
                DocumentationRepository.Create(_Documentation);
                var new_Documentation = DocumentationRepository.GetAll()
                    .FirstOrDefault(d=>d.phone==_Documentation.phone);
                if (new_Documentation != null)
                {
                    BaseRes.Data = new_Documentation;
                    BaseRes.Description = "УСПЕШНО!";
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<DocumentationViewModel>
                {
                    Description = $"[CreateDocumentation] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<DocumentationViewModel> DeleteDocumentation(DocumentationViewModel _Documentation)
        {
            var BaseRes = new DBResponse<DocumentationViewModel>();
            try
            {
                DocumentationRepository.Delete(_Documentation);
                var new_Documentation = DocumentationRepository.GetAll()
                    .FirstOrDefault(d => d.id == _Documentation.id);
                if (new_Documentation == null)
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
                return new DBResponse<DocumentationViewModel>
                {
                    Description = $"[DeleteDocumentation] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<DocumentationViewModel> EditDocumentation(DocumentationViewModel _Documentation)
        {
            var BaseRes = new DBResponse<DocumentationViewModel>();
            try
            {
                DocumentationRepository.Edit(_Documentation, _Documentation.id);
                var new_hostel = DocumentationRepository.GetAll()
                    .FirstOrDefault(d => d.id == _Documentation.id);
                if (new_hostel == _Documentation)
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
                return new DBResponse<DocumentationViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<DocumentationViewModel> GetDocumentation(string _phone)
        {
            var BaseRes = new DBResponse<DocumentationViewModel>();
            try
            {
                var Documentation = DocumentationRepository.Get(_phone);
                if (Documentation != null)
                {
                    BaseRes.Data = Documentation;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<DocumentationViewModel>
                {
                    Description = $"[GetDocumentation] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<DocumentationViewModel>> GetDocumentations(string hostel_name)
        {
            var BaseRes = new DBResponse<IEnumerable<DocumentationViewModel>>();
            try
            {
                var Documentations = DocumentationRepository.GetAll().Where(d=> d.hostel_name == hostel_name).ToList();
                if (Documentations.Count() != 0)
                {
                    BaseRes.Data = Documentations;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<DocumentationViewModel>>
                {
                    Description = $"[GetDocumentations] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<DocumentationViewModel>> GetDocumentations()
        {
            var BaseRes = new DBResponse<IEnumerable<DocumentationViewModel>>();
            try
            {
                var Documentations = DocumentationRepository.GetAll();
                if (Documentations.Count() != 0)
                {
                    BaseRes.Data = Documentations;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<DocumentationViewModel>>
                {
                    Description = $"[GetDocumentations] : {ex.Message}"
                };
            }
        }
    }
}
