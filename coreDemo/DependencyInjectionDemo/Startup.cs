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


            #region ע�᲻ͬ�������ڵķ���

            // ����
            services.AddSingleton<IMySingletonService, MySingletonService>();

            // ˲ʱ
            services.AddTransient<IMyTransientService, MyTransientService>();

            // ȫ��
            services.AddScoped<IMyScopedService, MyScopedService>();

            #endregion


            #region ��ʽע��

            services.AddSingleton<IOrderService>(new OrderService()); // ע��ʵ��
            // services.AddSingleton<IOrderService, OrderServiceEx>();
            // services.AddSingleton<IOrderService>(serviceProvide =>
            // {
            //     // ����
            //     return new OrderService();
            // });



            #endregion


            #region ����ע��

            // ��������ظ�ע�� ��ע����ʵ��
            // services.TryAddSingleton<IOrderService,OrderService>();
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());


            #endregion


            #region �Ƴ����滻

            // �滻
            services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());

            // �Ƴ�
            services.RemoveAll<IOrderService>(); // �����

            #endregion

            #region ע�᷺��ģ��

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
