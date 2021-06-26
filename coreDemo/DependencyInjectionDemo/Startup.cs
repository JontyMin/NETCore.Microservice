using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionDemo.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DependencyInjectionDemo
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
            services.AddControllers();


            #region 注册不同生命周期的服务

            // 单例
            services.AddSingleton<IMySingletonService, MySingletonService>();

            // 瞬时
            services.AddTransient<IMyTransientService, MyTransientService>();

            // 全局
            services.AddScoped<IMyScopedService, MyScopedService>();

            #endregion


            #region 花式注册

            services.AddSingleton<IOrderService>(new OrderService()); // 注入实例
            // services.AddSingleton<IOrderService, OrderServiceEx>();
            // services.AddSingleton<IOrderService>(serviceProvide =>
            // {
            //     // 工厂
            //     return new OrderService();
            // });



            #endregion


            #region 尝试注册

            // 避免服务重复注册 或注册多个实例
            // services.TryAddSingleton<IOrderService,OrderService>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());


            #endregion


            #region 移除或替换

            // 替换
            services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());

            // 移除
            services.RemoveAll<IOrderService>(); // 无输出

            #endregion

            #region 注册泛型模板

            services.AddSingleton(typeof(IGenericService<>), typeof(GenericService<>));

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
