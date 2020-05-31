using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRideTrackerWebApp.Data;

[assembly: HostingStartup(typeof(MyRideTrackerWebApp.Areas.Identity.IdentityHostingStartup))]
namespace MyRideTrackerWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AppIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AppIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AppIdentityContext>();
            });
        }
    }
}