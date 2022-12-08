using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Models;

namespace WebHostel.DAL.Repositories
{
    public class DocumentationRepository : IBaseRepository<DocumentationViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public DocumentationRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(DocumentationViewModel Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(DocumentationViewModel Entity)
        {
            var Doc = dbase.Documentation
                .Where(d => d.id == Entity.id).AsNoTracking()
                .FirstOrDefault();
            dbase.Remove(Doc);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(DocumentationViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public DocumentationViewModel Get(string unique_value)
        {
            return (from d in dbase.Documentation
                    join h in dbase.Hostel
                    on d.hostel_id equals h.id
                    where d.phone == unique_value
                    select new DocumentationViewModel
                    {
                        id = d.id,
                        fullname = d.fullname,
                        phone = d.phone,
                        status = d.status,
                        regdate = d.regdate,
                        fullstatus = d.fullstatus,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public DocumentationViewModel Get(string unique_value, string _hostel_name)
        {
            return (from d in dbase.Documentation
                    join h in dbase.Hostel
                    on d.hostel_id equals h.id
                    where d.phone == unique_value
                    && h.title == _hostel_name
                    select new DocumentationViewModel
                    {
                        id = d.id,
                        fullname = d.fullname,
                        phone = d.phone,
                        status = d.status,
                        regdate = d.regdate,
                        fullstatus = d.fullstatus,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public IEnumerable<DocumentationViewModel> GetAll()
        {
            return (from d in dbase.Documentation
                    join h in dbase.Hostel
                    on d.hostel_id equals h.id
                    select new DocumentationViewModel 
                    {
                        id = d.id,
                        fullname = d.fullname,
                        phone = d.phone,
                        regdate = d.regdate,
                        status = d.status,
                        fullstatus = d.fullstatus,
                        hostel_name = h.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
