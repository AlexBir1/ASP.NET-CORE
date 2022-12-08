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
    public class RoomsRepository : IBaseRepository<RoomsViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public RoomsRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(RoomsViewModel Entity)
        {
            dbase
            .Database
            .ExecuteSqlRaw
            ($"call CreateRoom(" +
            $"'{Entity.num}', " +
            $"'{Entity.rank}', " +
            $"'{Entity.CostPerDay}'), " +
            $"'{Entity.maxPeople}'), " +
            $"'{Entity.hostel_name}')");
            return true;
        }

        public bool Delete(RoomsViewModel Entity)
        {
            var _room = dbase.Rooms
                .Where(r => r.id == Entity.id)
                .FirstOrDefault();
            dbase.Remove(_room);
            dbase.SaveChanges();
            return true;
        }

        public bool Edit(RoomsViewModel Entity, int id)
        {
            var _room = dbase.Rooms.Where(r => r.id == Entity.id).FirstOrDefault();
            _room.num = Entity.num;
            _room.rank = (int)Entity.rank;
            _room.maxPeople = Entity.maxPeople;
            _room.CostPerDay = Entity.CostPerDay;
            dbase.Update(_room);
            dbase.SaveChanges();
            return true;
        }

        public RoomsViewModel Get(string unique_value)
        {
            return (from r in dbase.Rooms
                    join h in dbase.Hostel
                    on r.hostel_id equals h.id
                    where h.title == unique_value
                    select new RoomsViewModel
                    {
                        id = r.id,
                        num = r.num,
                        maxPeople = r.maxPeople,
                        rank = (RoomRanks)r.rank,
                        CostPerDay = r.CostPerDay,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public RoomsViewModel Get(string unique_value, string _hostel_name)
        {
            return (from r in dbase.Rooms
                    join h in dbase.Hostel
                    on r.hostel_id equals h.id
                    where r.num == Int32.Parse(unique_value)
                    && h.title == unique_value
                    select new RoomsViewModel
                    {
                        id = r.id,
                        num = r.num,
                        maxPeople = r.maxPeople,
                        rank = (RoomRanks)r.rank,
                        CostPerDay = r.CostPerDay,
                        hostel_name = h.title
                    }).FirstOrDefault();
        }

        public IEnumerable<RoomsViewModel> GetAll()
        {
            return (from r in dbase.Rooms
                    join h in dbase.Hostel
                    on r.hostel_id equals h.id
                    
                    select new RoomsViewModel
                    {
                        id = r.id,
                        num = r.num,
                        maxPeople = r.maxPeople,
                        rank = (RoomRanks)r.rank,
                        CostPerDay = r.CostPerDay,
                        hostel_name = h.title
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            return (from r in dbase.Rooms
                    join h in dbase.Hostel
                    on r.hostel_id equals h.id
                    select r.id).FirstOrDefault();
        }

    }
}
