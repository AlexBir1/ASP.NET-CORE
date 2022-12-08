using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.DAL.Interfaces;
using WebHostel.Domain.Entity;
using WebHostel.Domain.Enum;
using WebHostel.Models;

namespace WebHostel.DAL.Repositories
{
    public class ProfilesRepository : IBaseRepository<ProfilesViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public ProfilesRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(ProfilesViewModel Entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProfilesViewModel Entity)
        {
            throw new NotImplementedException();
        }

        public bool Edit(ProfilesViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public ProfilesViewModel Get(string unique_value)
        {
            throw new NotImplementedException();
        }

        public ProfilesViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfilesViewModel> GetAll()
        {
            return (from p in dbase.Profiles
                    select new ProfilesViewModel
                    {
                        id = p.id,
                        login = p.login,
                        password = p.passw,
                        status = (UserStatus)p.status
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            throw new NotImplementedException();
        }
    }
}
