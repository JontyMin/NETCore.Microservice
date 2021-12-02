using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Acme.MyConsoleApp
{
    public class MyConsoleAppHostedService : IHostedService
    {
        private readonly IAbpApplicationWithExternalServiceProvider _application;
        private readonly IServiceProvider _serviceProvider;
        private readonly HelloWorldService _helloWorldService;

        public MyConsoleAppHostedService(
            IAbpApplicationWithExternalServiceProvider application,
            IServiceProvider serviceProvider,
            HelloWorldService helloWorldService)
        {
            _application = application;
            _serviceProvider = serviceProvider;
            _helloWorldService = helloWorldService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // 初始化应用程序
            _application.Initialize(_serviceProvider);

            // 调用服务
            _helloWorldService.SayHello();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _application.Shutdown();

            return Task.CompletedTask;
        }
    }
}
