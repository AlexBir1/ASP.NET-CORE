using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    interface IManufactorerService
    {
        public IBaseResponse<ManufactorerViewModel> 
            CreateManufactorer(ManufactorerViewModel manufactorer);
        public IBaseResponse<ManufactorerViewModel> 
            DeleteManufactorer(ManufactorerViewModel manufactorer);
        public IBaseResponse<ManufactorerViewModel> 
            EditManufactorer(ManufactorerViewModel manufactorer);
        public IBaseResponse<IEnumerable<ManufactorerViewModel>> GetManufactorers();
    }
}
