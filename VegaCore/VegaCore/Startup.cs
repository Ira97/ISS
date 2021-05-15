using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiddleWares;
using Models.Setting;
using React.AspNet;
using WebApiHandlers.Interfaces;
using WebApiHandlers.Providers;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using JavaScriptEngineSwitcher.V8;

namespace Vega
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
            });

            services.AddControllersWithViews();
            services.AddScoped<IWebHttpClientProvider, WebHttpClientProvider>();
           
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserProvider, UserProvider>();
           
            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));
            services.AddMemoryCache();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName).AddV8();

            services.AddDistributedMemoryCache();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

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
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseSession();
            app.UseStaticFiles();
            app.UseReact(config => { });
            app.UseEndpoints(endpoints => { endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); });
        }
    }
}
