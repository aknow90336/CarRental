using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarRental.DataAccess.DB.CarDB;
using Microsoft.EntityFrameworkCore;
using CarRental.Frontend.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using CarRental.Frontend.Lib;
using AutoMapper;

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
            #region AutoMap 
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            services.AddDbContext<CarDBContext>(options => options.UseMySql("server=172.31.32.2;Port=3306;Database=car;User=root;Password=Abc12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.18-mysql")), ServiceLifetime.Transient);
            services.AddControllersWithViews(x=>x.SuppressAsyncSuffixInActionNames = false).AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>{
                option.Cookie.HttpOnly = true;
                option.LoginPath = new PathString("/User/Login");
                option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });      
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

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();

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
