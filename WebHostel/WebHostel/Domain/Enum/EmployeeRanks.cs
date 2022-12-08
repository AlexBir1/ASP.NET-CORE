using System.ComponentModel.DataAnnotations;

namespace WebHostel.Domain.Enum
{
    public enum EmployeeRanks
    {
        [Display(Name = "Консьерж")]
        Concierge = 1,
        [Display(Name = "Тренер")]
        Trainer,
        [Display(Name = "Уборщик")]
        Cleaner,
        [Display(Name = "Регистратор")]
        Registrator,
        [Display(Name = "СисАдмин")]
        SystemAdmin
    }
}
