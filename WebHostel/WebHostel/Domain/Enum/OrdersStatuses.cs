using System.ComponentModel.DataAnnotations;

namespace WebHostel.Domain.Enum
{
    public enum OrdersStatuses
    {
        [Display(Name = "Заказано")]
        set = 0,
        [Display(Name = "Готовится")]
        making,
        [Display(Name = "ГОТОВО")]
        made
    }
}
