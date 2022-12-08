using System.ComponentModel.DataAnnotations;

namespace WebHostel.Domain.Enum
{
    public enum BookingStatuses
    {
        [Display(Name = "Не бронь")]
        isNotBooked = 0,
        [Display(Name = "Бронь")]
        isBooked
    }
}
