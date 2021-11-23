using Kubrakowo.WebApp.Domain.Entities;
using Kubrakowo.WebApp.Areas.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Kubrakowo.WebApp.Domain;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace Kubrakowo.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {

            builder.ConfigureServices((context, services) =>
            {
                services.AddDefaultIdentity<User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddRoles<IdentityRole<int>>()
                    .AddEntityFrameworkStores<Context>();
            });
        }
    }
}