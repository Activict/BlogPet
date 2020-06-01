using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Web.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using MyBlog.DAL.Interfaces;
using MyBlog.DAL;
using AutoMapper;
using MyBlog.BLL.Interfaces;
using MyBlog.BLL.Services;
using MyBlog.BLL.Interfaces.Account;

namespace MyBlog.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PageCounter>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));
            
            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
