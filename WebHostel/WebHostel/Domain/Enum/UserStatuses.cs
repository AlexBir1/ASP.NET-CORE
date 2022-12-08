using System.ComponentModel.DataAnnotations;

namespace WebHostel.Domain.Enum
{
    public enum UserStatus
    {
        [Display(Name = "Клиент")]
        customer = 1,
        [Display(Name = "Работник")]
        employee,
        [Display(Name = "Администратор")]
        admin
    }
}
