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
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using DependencyInjectionAutofacDemo.Services;

namespace DependencyInjectionAutofacDemo
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
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            // builder.RegisterType<MyService>().As<IMyService>();

            // ����ע��
            // builder.RegisterType<MyService2>().Named<IMyService>("service2");

            #region ����ע��

            // builder.RegisterType<MyNameService>(); // ��Ϊ�� ����ע��
            // builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired();

            #endregion

            #region AOP

            // builder.RegisterType<MyInterceptor>();
            // builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired()
            //     .InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();
            /*
             * EnableInterfaceInterceptors �ӿ�������
             * EnableClassInterceptors �������� ��Ҫ������鷽��
             */
            #endregion

            #region ������

            builder.RegisterType<MyNameService>().InstancePerMatchingLifetimeScope("myScope");

            #endregion
        }


        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            // var service = this.AutofacContainer.Resolve<IMyService>();
            // var service = this.AutofacContainer.ResolveNamed<IMyService>("service2");
            // service.ShowCode();

            #region ������

            using (var myScope = AutofacContainer.BeginLifetimeScope("myScope"))
            {
                var service = myScope.Resolve<MyNameService>();
                using (var scope = myScope.BeginLifetimeScope())
                {
                    var service1 = scope.Resolve<MyNameService>();
                    var service2 = scope.Resolve<MyNameService>();
                    Console.WriteLine($"service1=service2:{service1==service2}");
                    Console.WriteLine($"service1=service:{service1==service}");
                }
            }

            #endregion

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
