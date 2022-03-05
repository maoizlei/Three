using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Three.Services;

namespace Three
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
            //注册服务
            services.AddControllersWithViews();
            //做web api时，没有view
            //services.AddControllers();

            //services.AddRazorPages();

            //每次请求IClock时，返回ChinaClock
            //services.AddSingleton<IClock, ChinaClock>();            
            //services.AddSingleton<IClock, UTCClock>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

        }

        /// <summary>
        /// development优先进入这个方法
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        //public void ConfigureDevelopment(IApplicationBuilder app, IWebHostEnvironment env)
        //{ }

        /// <summary>
        /// 配置管道
        /// CreateDefaultBuilder 时注入
        /// </summary>
        /// <param name="app">服务，通过依赖注入的方式将他注入</param>
        /// <param name="env">注入</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //不同的模式
            //开发模式
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //将http转换为https请求
            app.UseHttpsRedirection();
            //使用静态文件，不需要知道路由信息
            app.UseStaticFiles();

            //路由中间件，检查注册的端点
            app.UseRouting();
            //身份认证
            app.UseAuthorization();

            //注册端点
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapRazorPages();
                //endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("hello world!");
                // });
                //mvc
                endpoints.MapControllerRoute("default", "{controller=Department}/{action=Index}/{id?}");
                //使用Attribute方式
                //endpoints.MapControllers();
            });
         }
    }
}
