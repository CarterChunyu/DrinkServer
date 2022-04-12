using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Data;
using Microsoft.EntityFrameworkCore;
using DrinkServer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Pomelo.EntityFrameworkCore.MySql;

namespace DrinkServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //153

            services.AddDbContext<DrinkContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DrinkConnectionString"));
            });
            services.AddDbContext<Yavis_OrderDbContext>(builder =>
            {
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //232

            //services.AddDbContext<DrinkContext>(builder =>
            //{
            //    string conn = Configuration.GetConnectionString("DrinkConnectionString");
            //    builder.UseMySql(conn, ServerVersion.AutoDetect(conn));
            //});

            //services.AddDbContext<Yavis_OrderDbContext>(builder =>
            //{
            //    string conn = Configuration.GetConnectionString("DefaultConnection");
            //    builder.UseMySql(conn, ServerVersion.AutoDetect(conn));
            //});


            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<INLogService, NLogService>();
            services.AddScoped<OrderService>();
            services.AddDistributedMemoryCache();
            services.AddSession(options=> {
                options.IdleTimeout = TimeSpan.FromDays(1);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = new PathString("/Login/Login");
                    option.LogoutPath = new PathString("/Login/Logout");
                    option.AccessDeniedPath = new PathString("/Login/NoPermission");
                    option.ExpireTimeSpan = TimeSpan.FromDays(1);
                    // todo check
                    option.SlidingExpiration = false;
                });

            services.AddHttpContextAccessor();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
