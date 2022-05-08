using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
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
            #region Automatically resolve all dependencies

            Assembly.Load("CarRental.DataAccess");
            Assembly.Load("CarRental.Service");
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("CarRental.Service") || x.FullName.Contains("CarRental.DataAccess"));
            foreach(var assemblie in assemblies) {
                foreach(var intfc in assemblie.ExportedTypes.Where(t=>t.IsInterface)){
                    var impl = assemblie.ExportedTypes.FirstOrDefault(c=>c.IsClass && intfc.Name.Substring(1) == c.Name);
                    
                    if (impl != null){
                        System.Console.WriteLine(impl.AssemblyQualifiedName);
                        services.AddScoped(intfc, impl);
                        // 先以有狀態服務設計(Scoped) 如遇到問題再看是否用 AddTransient 處理
                    }
                }
            }

            #endregion
            // services.AddScoped<ICarRepository, CarRepository>();
            // services.AddScoped<ICarService, CarService>();
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
