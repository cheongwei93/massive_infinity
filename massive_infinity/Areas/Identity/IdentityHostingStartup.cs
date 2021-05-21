using System;
using massive_infinity.Areas.Identity.Data;
using massive_infinity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(massive_infinity.Areas.Identity.IdentityHostingStartup))]
namespace massive_infinity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<massive_infinityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("massive_infinityContextConnection")));

                services.AddDefaultIdentity<massive_infinityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<massive_infinityContext>();
            });
        }
    }
}