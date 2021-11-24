using kubrakowo.Data;
using Kubrakowo.WebApp.Domain;
using Kubrakowo.WebApp.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kubrakowo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            services.AddDbContextFactory<Context>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
#if DEBUG
                    options.EnableSensitiveDataLogging();
#endif
                });

            //TODO: Verify what is better - transient/scoped 
            services.AddTransient<Context>(p => p.GetRequiredService<IDbContextFactory<Context>>().CreateDbContext());

            services.AddScoped<IFileStorageService, FileStorageService>();
            ConfigureAuthentication(services);
            services.AddScoped<NotificationService>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.ConsentCookie.IsEssential = true;//<-- NOTE THIS
                options.CheckConsentNeeded = context => false;
            });
        }

        private static void ConfigureAuthentication(IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = $"/Identity/Account/Login";
                opts.LogoutPath = $"/Identity/Account/Logout";
                opts.ExpireTimeSpan = TimeSpan.FromSeconds(3000);
                opts.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
