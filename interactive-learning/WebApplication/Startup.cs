using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApplication
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10000000);
                options.Cookie.HttpOnly = true;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();
            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute("profesor", "professor",
                defaults: new { controller = "Professor", action = "professor" });
                routes.MapRoute("profesor", "ProfessorAnswers",
                defaults: new { controller = "Professor", action = "ProfessorAnswers" });
                routes.MapRoute("profesor", "AddRoom",
                     defaults: new { controller = "Professor", action = "AddRoom" });
                routes.MapRoute("profesor", "JoinRoom",
                     defaults: new { controller = "Professor", action = "JoinRoom" });
                routes.MapRoute("profesor", "CloseRoom",
                     defaults: new { controller = "Professor", action = "CloseRoom" });
                routes.MapRoute("profesor", "LeaveRoom",
                 defaults: new { controller = "Professor", action = "LeaveRoom" });
                routes.MapRoute("profesor", "AddQuestion",
                     defaults: new { controller = "Professor", action = "AddQuestion" });
                routes.MapRoute("profesor", "AddAnswer",
                     defaults: new { controller = "Professor", action = "AddAnswer" });
                routes.MapRoute("student", "student",
                    defaults: new { controller = "Student", action = "Student" });
                routes.MapRoute("student", "StudentEnterCourse",
                    defaults: new { controller = "Student", action = "StudentEnterCourse" });
                routes.MapRoute("student", "AddQuestionStudent",
                  defaults: new { controller = "Student", action = "AddQuestionStudent" });
                routes.MapRoute("student", "AddAnswerStudent",
                  defaults: new { controller = "Student", action = "AddAnswerStudent" });
                routes.MapRoute("student", "StudentAnswers",
                  defaults: new { controller = "Student", action = "StudentAnswers" });
                routes.MapRoute("student", "CheckRoomExpiration",
                 defaults: new { controller = "Student", action = "CheckRoomExpiration" });
                routes.MapRoute("student", "CheckToken",
                 defaults: new { controller = "Student", action = "CheckToken" });
                routes.MapRoute("student", "JoinRoomStudent",
                 defaults: new { controller = "Student", action = "JoinRoomStudent" });
                routes.MapRoute("student", "LeaveRoomStudent",
                 defaults: new { controller = "Student", action = "LeaveRoomStudent" });


            });
        }
    }
}
