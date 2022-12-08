using System.ComponentModel.DataAnnotations;

namespace WebHostel.Domain.Enum
{
    public enum WOStatuses
    {
        [Display(Name = "В дороге")]
        not_ready = 0,
        [Display(Name = "НА МЕСТЕ")]
        ready
    }
}
