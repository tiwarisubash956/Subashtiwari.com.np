using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio
{
    public class Startup
    {
        private IConfiguration _config;

        // Using IConfiguration dependency injection to configure application.
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            services.AddAuthorization(options => 
            {
                options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role"));
            });
            services.AddAuthentication()
                    .AddGoogle(options => 
                    {
                        options.ClientId = "613715537189-ovaa58i5nd7mut2tq041irv222mq0l2v.apps.googleusercontent.com";
                        options.ClientSecret = "_Dje8fC_v-py-CRlWgGp6Mql";
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The Configure method consists of several middleware depending on our application requirements.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(route => {
                route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            /*app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hi!, My name is Kuldeep Singh Chouhan.\n");
                await context.Response.WriteAsync(_config["Profession"]);
                await next();

            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\nThe current process process which is being used to run this server is: " + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            });*/
        }
    }
}