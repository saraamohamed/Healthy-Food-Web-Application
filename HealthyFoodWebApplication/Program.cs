using HealthyFoodWebApplication.Models;
using HealthyFoodWebApplication.Repositories.CustomerMessageRepository;
using HealthyFoodWebApplication.Repositories.LoggerRepository;
using HealthyFoodWebApplication.Repositories.ProductRepository;
using HealthyFoodWebApplication.Repositories.ShoppingBag;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace HealthyFoodWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<HealthyFoodDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


            builder.Services.AddScoped<IProductRepository,ProductRepository>();
            builder.Services.AddScoped<IShoppingBagRepository, ShoppingBagRepository>();
            builder.Services.AddScoped<ICustomerMessageRepository, CustomerMessageRepository>();
            builder.Services.AddScoped<ILoggerRepository, LoggerRepository>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            builder.Services.AddHttpContextAccessor();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=GetHomeView}/{id?}");

            app.Run();
        }
    }
}