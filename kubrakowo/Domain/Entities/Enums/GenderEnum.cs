using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Domain.Entities.Enums
{
    public enum GenderEnum : byte
    {
        [Display(Name = "Mężczyźni")]
        Male = 1,
        [Display(Name = "Kobiety")]
        Female,
        [Display(Name = "Dzieci")]
        Kids,
    }
}
