using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kubrakowo.WebApp.Domain.Entities.Enums
{
    public enum SizeEnum : byte
    {
        [Display(Name = "XS")]
        XS = 1,
        [Display(Name = "S")]
        S,
        [Display(Name = "M")]
        M,
        [Display(Name = "L")]
        L,
        [Display(Name = "XL")]
        XL,
        [Display(Name = "XXL")]
        XXL,
        [Display(Name = "XXXL")]
        XXXL,
    }
}
