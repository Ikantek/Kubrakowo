using System.ComponentModel.DataAnnotations;

namespace Kubrakowo.WebApp.Domain.Entities.Enums
{
    public enum OfferTypeEnum : byte
    {
        [Display(Name = "Nie opłacona")]
        NotPaid = 1,
        [Display(Name = "Aktywna")]
        Active,
        [Display(Name = "Wygasła")]
        Expired,
    }
}
