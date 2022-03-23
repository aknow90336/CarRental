using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarRental.DataAccess.DB.CarDB;
using Microsoft.EntityFrameworkCore;
using CarRental.DataAccess.Interface;
using CarRental.DataAccess.Repository;
using CarRental.Service;
using CarRental.Service.Impl;

namespace CarRental.Frontend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Singleton Scoped Transient
            // IOC DI
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();
            services.AddDbContext<CarDBContext>(options => options.UseMySql("server=54.95.104.25;Port=3306;Database=car;User=root;Password=Abc12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql")), ServiceLifetime.Transient);
            services.AddControllersWithViews(x=>x.SuppressAsyncSuffixInActionNames = false).AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
