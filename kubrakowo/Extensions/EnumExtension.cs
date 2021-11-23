using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Kubrakowo.WebApp.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue) =>
            enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        .GetName();
    }
}
