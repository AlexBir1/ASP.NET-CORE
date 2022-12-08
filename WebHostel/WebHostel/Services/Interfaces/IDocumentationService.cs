using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IDocumentationService
    {
        public IBaseResponse<DocumentationViewModel> CreateDocumentation(DocumentationViewModel _Documentation);
        public IBaseResponse<DocumentationViewModel> EditDocumentation(DocumentationViewModel _Documentation);
        public IBaseResponse<DocumentationViewModel> DeleteDocumentation(DocumentationViewModel _Documentation);
        public IBaseResponse<DocumentationViewModel> GetDocumentation(string _phone);
        public IBaseResponse<IEnumerable<DocumentationViewModel>> GetDocumentations();
        public IBaseResponse<IEnumerable<DocumentationViewModel>> GetDocumentations(string hostel_name);
    }
}
