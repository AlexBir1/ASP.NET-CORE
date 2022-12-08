using System.ComponentModel.DataAnnotations;

namespace WebHostel.Domain.Enum
{
    public enum PrivacyRStatuses
    {
        [Display(Name = "Свободно")]
        isNotPrivate = 0,
        [Display(Name = "Приватно")]
        isPrivate

    }
}
