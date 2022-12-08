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
    public class BookingService : IBookingService
    {
        private readonly BookingRepository BookingRepository;

        public BookingService(BookingRepository _BookingRepository)
        {
            BookingRepository = _BookingRepository;
        }

        public IBaseResponse<BookingViewModel> CreateBooking(BookingViewModel _booking)
        {
            var BaseRes = new DBResponse<BookingViewModel>();
            try
            {
                BookingRepository.Create(_booking);
                var new_booking = BookingRepository.GetAll()
                    .FirstOrDefault(b=>b.room_num == _booking.room_num 
                    && b.customer_num == _booking.customer_num);
                if (new_booking != null)
                {
                    
                    BaseRes.Data = new_booking;
                    BaseRes.Description = "БРОНИРОВАНИЕ ПРОШЛО УСПЕШНО!";
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА БРОНИРОВАНИЯ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<BookingViewModel>
                {
                    Description = $"[CreateBooking] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<BookingViewModel> DeleteBooking(BookingViewModel _booking)
        {
            var BaseRes = new DBResponse<BookingViewModel>();
            try
            {
                BookingRepository.Delete(_booking);
                var new_booking = BookingRepository.GetAll()
                    .FirstOrDefault(b => b.room_num == _booking.room_num
                    && b.customer_num == _booking.customer_num);
                if (new_booking == null)
                {
                    BaseRes.Description = "УДАЛЕНИЕ БРОНИ УСПЕШНО!";
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА УДАЛЕНИЯ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<BookingViewModel>
                {
                    Description = $"[DeleteBooking] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<BookingViewModel> EditBooking(BookingViewModel _booking)
        {
            var BaseRes = new DBResponse<BookingViewModel>();
            try
            {
                BookingRepository.Edit(_booking, _booking.id);
                var new_hostel = BookingRepository.GetAll()
                    .FirstOrDefault(b => b.room_num == _booking.room_num
                    && b.customer_num == _booking.customer_num);
                if (new_hostel == _booking)
                {
                    BaseRes.Description = "ИЗМЕНЕНИЕ БРОНИ УСПЕШНО!";
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "ОШИБКА РЕДАКТИРОВАНИЯ!";
                BaseRes.StatusCode = StatusCode.InternalServiceError;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<BookingViewModel>
                {
                    Description = $"[EditHostel] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<BookingViewModel> GetBooking(string _customer_phone)
        {
            var BaseRes = new DBResponse<BookingViewModel>();
            try
            {
                var booking = BookingRepository.Get(_customer_phone);
                if (booking != null)
                {
                    BaseRes.Data = booking;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<BookingViewModel>
                {
                    Description = $"[GetBooking] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<BookingViewModel>> GetBookings()
        {
            var BaseRes = new DBResponse<IEnumerable<BookingViewModel>>();
            try
            {
                var bookings = BookingRepository.GetAll();
                if (bookings.Count() != 0)
                {
                    BaseRes.Data = bookings;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<BookingViewModel>>
                {
                    Description = $"[GetBookings] : {ex.Message}"
                };
            }
        }

        public IBaseResponse<IEnumerable<BookingViewModel>> GetBookings(string PHONE)
        {
            var BaseRes = new DBResponse<IEnumerable<BookingViewModel>>();
            try
            {
                var bookings = BookingRepository.GetAll().Where(b=>b.customer_num==PHONE).ToList();
                if (bookings.Count() != 0)
                {
                    BaseRes.Data = bookings;
                    BaseRes.StatusCode = StatusCode.OK;
                    return BaseRes;
                }
                BaseRes.Description = "Список пуст!";
                BaseRes.StatusCode = StatusCode.NotFound;
                return BaseRes;
            }
            catch (Exception ex)
            {
                return new DBResponse<IEnumerable<BookingViewModel>>
                {
                    Description = $"[GetBookings] : {ex.Message}"
                };
            }
        }
    }
}
