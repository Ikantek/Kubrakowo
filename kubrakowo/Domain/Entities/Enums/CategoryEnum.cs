using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Domain.Entities.Enums
{
    public enum CategoryEnum : byte
    {
        [Display(Name = "Buty")]
        Shoes = 1,
        [Display(Name = "Kurtki i płaszcze")]
        Coat,
        [Display(Name = "Swetry")]
        Sweater,
        [Display(Name = "Koszulki")]
        TShirt,
        [Display(Name = "Bluzy")]
        Blouse,
        [Display(Name = "Koszule")]
        Shirt,
        [Display(Name = "Sukienki")]
        Skirt
    }
}
