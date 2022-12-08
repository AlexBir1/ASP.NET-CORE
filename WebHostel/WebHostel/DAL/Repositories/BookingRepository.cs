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
    public class BookingRepository : IBaseRepository<BookingViewModel>
    {
        private readonly ApplicationDBContext dbase;

        public BookingRepository(ApplicationDBContext db)
        {
            dbase = db;
        }

        public bool Create(BookingViewModel Entity)
        {
            dbase
            .Database
            .ExecuteSqlRaw
            ($"call AddBooking('{Entity.room_num}', '{Entity.book_date.ToString("yyyy-MM-dd")}', '{Entity.customer_num}')");
            return true;
        }

        public bool Delete(BookingViewModel Entity)
        {
            dbase
            .Database
            .ExecuteSqlRaw
            ($"call DelBooking('{Entity.room_num}', '{Entity.customer_num}')");
            return true;
        }

        public bool Edit(BookingViewModel Entity, int id)
        {
            throw new NotImplementedException();
        }

        public BookingViewModel Get(string unique_value)
        {
            return (from r in dbase.Rooms
                    join b in dbase.Booking
                     on r.id equals b.rooms_id
                    where b.customer_phone == unique_value
                    select new BookingViewModel
                    {
                        id = b.id,
                        room_num = r.num,
                        book_date = b.book_date,
                        customer_num = b.customer_phone
                    }).FirstOrDefault();
        }

        public IEnumerable<BookingViewModel> GetAll()
        {
            return (from r in dbase.Rooms
                    join b in dbase.Booking
                     on r.id equals b.rooms_id
                    select new BookingViewModel
                    {
                        id = b.id,
                        room_num = r.num,
                        book_date = b.book_date,
                        customer_num = b.customer_phone
                    }).ToList();
        }

        public int GetID(string unique_value)
        {
            return (from r in dbase.Rooms
                   join b in dbase.Booking
                    on r.id equals b.rooms_id
                    where r.num == int.Parse(unique_value)
                   select r.id).Single();
        }

        public BookingViewModel Get(string unique_value, string _hostel_name)
        {
            throw new NotImplementedException();
        }
    }
}
