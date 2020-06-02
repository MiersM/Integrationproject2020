using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HP_Project.DAL;
using HP_Project.DAL.Models;
using HP_Project.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HP_Project
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
            services.AddDbContextPool<AppDbContext>(
                options =>
                    //options.UseSqlServer(Configuration.GetConnectionString("ApolloDBConnection"))
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddControllersWithViews();
            services.AddScoped<IApolloRepository, ApolloRepository>();
            services.AddScoped<IClientEmployeeRepository, ClientEmployeeRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IInstallBaseRepository, InstallBaseRepository>();
            services.AddScoped<IProductHierarchyRepository, ProductHierarchyRepository>();
            services.AddScoped<IRADRepository, RADRepository>();
            services.AddScoped<IRevenueActualsRepository, RevenueActualsRepository>();
            services.AddScoped<ITerritoryCompanyRepository, TerritoryCompanyRepository>();
            services.AddScoped<ITouchpointRepository, TouchpointRepository>();
            services.AddScoped<IWorkdayRepository, WorkdayRepository>();
            services.AddScoped<IInsightRepository, InsightRepository>();
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
