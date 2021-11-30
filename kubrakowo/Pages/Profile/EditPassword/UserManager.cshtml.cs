using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kubrakowo.WebApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kubrakowo.WebApp.Pages.Profile.EditPassword
{
    [IgnoreAntiforgeryToken]
    public class UserManagerModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public UserManagerModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnPostEditAsync([FromBody] PasswordEditModel model)
        {
            var user = _userManager.FindByIdAsync(model.Id.ToString()).Result;
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, model.Password);
        }
    }
}
