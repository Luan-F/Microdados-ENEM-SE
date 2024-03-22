using testando;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MicrodadosEnemSergipe.WebApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using static AccountController;

namespace testando
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

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });


            services.AddDbContext<ContextConnection>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("ContextConnection")));
       
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

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "logout",
                    pattern: "Account/Logout",
                    defaults: new { controller = "Account", action = "Logout" });

                //endpoints.MapControllerRoute(
                //    name: "login",
                //    pattern: "login",
                //    defaults: new { controller = "Account", action = "Login" });
                //endpoints.MapControllerRoute(
                //    name: "upload",
                //    pattern: "upload",
                //    defaults: new { controller = "Account", action = "ImportDados" });
                //endpoints.MapControllerRoute(
                //    name: "uploadSuccess",
                //    pattern: "upload/success",
                //    defaults: new { controller = "Account", action = "ImportacaoConcluida" });
            });
        }
    }
}
