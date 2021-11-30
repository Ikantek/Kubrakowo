using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace Kubrakowo.WebApp.Extensions
{
    public static class AuthenticationStateExtensions
    {
        public static string GetUserNickName(this AuthenticationState state) => state.User.Identity?.Name;

        public static int GetUserId(this AuthenticationState state)
        {
            var userIdString = state.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdString, out var userId))
                return userId;

            throw new Exception("Can't get userId");
        }
    }
}
