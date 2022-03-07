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
using ThreePage;
using ThreePage.Services;

namespace ThreePage
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
            //ע�����
            services.AddRazorPages();

            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();

            services.Configure<ThreeOptions>(Configuration.GetSection("Three"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //��ͬ��ģʽ
            //����ģʽ
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
            //��httpת��Ϊhttps����
            app.UseHttpsRedirection();
            //ʹ�þ�̬�ļ�������Ҫ֪��·����Ϣ
            app.UseStaticFiles();

            //·���м�������ע��Ķ˵�
            app.UseRouting();
            //�����֤
            app.UseAuthorization();

            //ע��˵�
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
