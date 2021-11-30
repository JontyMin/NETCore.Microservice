using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.MyConsoleApp
{

    /**
     * 依赖模块
     */

    [DependsOn(
        typeof(AbpAutofacModule)
    )]
    public class MyConsoleAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostEnvironment = context.Services.GetSingletonInstance<IHostEnvironment>();

            // 注册服务
            context.Services.AddHostedService<MyConsoleAppHostedService>();
        }

    }
}
