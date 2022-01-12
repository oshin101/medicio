using System;
using medicio.Areas.Identity.Data;
using medicio.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(medicio.Areas.Identity.IdentityHostingStartup))]
namespace medicio.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<medicioContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("medicioContextConnection")));
                
                services.AddDefaultIdentity<medicioUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<medicioContext>();
            });
        }
    }
}