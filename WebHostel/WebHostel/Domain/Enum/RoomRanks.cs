using System.ComponentModel.DataAnnotations;

namespace WebHostel.Domain.Enum
{
    public enum RoomRanks
    {
        [Display(Name = "Стандарт")]
        Standart = 1,
        [Display(Name = "Бизнес-класс")]
        Business,
        [Display(Name = "Люкс")]
        Lux
    }
}
