using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHostel.Domain.Response;
using WebHostel.Models;

namespace WebHostel.Services.Interfaces
{
    public interface IBookingService
    {
        public IBaseResponse<BookingViewModel> CreateBooking(BookingViewModel _booking);
        public IBaseResponse<BookingViewModel> DeleteBooking(BookingViewModel _booking);
        public IBaseResponse<BookingViewModel> GetBooking(string _customer_phone);
        public IBaseResponse<IEnumerable<BookingViewModel>> GetBookings();
        public IBaseResponse<IEnumerable<BookingViewModel>> GetBookings(string PHONE);
        public IBaseResponse<BookingViewModel> EditBooking(BookingViewModel _booking);
    }
}
