﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GolfApp
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

            services.AddRazorPages();

            services.AddDbContext<ShaftDbContext>(options =>
            {
<<<<<<< HEAD
                options.UseMySql(Configuration["ConnectionStrings:LibertyDbConnection"]);
=======
                options.UseMySql(Configuration["ConnectionStrings:ShaftDbConnection"]);
>>>>>>> c26794e98f3a8255a520aa136b7f8b5eaf998941
            });

            services.AddDbContext<AppIdentityDBContext>(options =>
                options.UseMySql(Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDBContext>();
            
            services.AddScoped<IShaftRepository, EFShaftRepository>();
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

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page={pageNum}",
                    defaults: new { Controller = "Home", action = "Products", pageNum = 1 });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
