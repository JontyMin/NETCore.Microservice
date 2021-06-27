using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DependencyInjectionDemo.Services;

namespace DependencyInjectionDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


/*
 * 大部分接口都要使用的时候用构造函数注入
 * 只有一个接口使用推荐使用[FromService]注入
 */

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IGenericService<IOrderService> _genericService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,IGenericService<IOrderService>genericService)
        {
            _logger = logger;
            _genericService = genericService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route(nameof(GetService))]
        public int GetService([FromServices] IMySingletonService singletonService1,
            [FromServices] IMySingletonService singletonService2,
            [FromServices] IMyScopedService scopedService1,
            [FromServices] IMyScopedService scopedService2,
            [FromServices] IMyTransientService transientService1,
            [FromServices] IMyTransientService transientService2
            )
        {
            Console.WriteLine($"singleton1:{singletonService1.GetHashCode()}");
            Console.WriteLine($"singleton2:{singletonService2.GetHashCode()}");

            Console.WriteLine($"transient1:{transientService1.GetHashCode()}");
            Console.WriteLine($"transient2:{transientService2.GetHashCode()}");

            Console.WriteLine($"scoped1:{scopedService1.GetHashCode()}");
            Console.WriteLine($"scoped2:{scopedService2.GetHashCode()}");

            Console.WriteLine("请求结束");
            return 1;
        }

        [HttpGet]
        [Route(nameof(GetServiceList))]
        public int GetServiceList([FromServices] IEnumerable<IOrderService> services)
        {
            foreach (var item in services)
            {
                Console.WriteLine($"获取到服务实例：{item}:{item.GetHashCode()}");
            }

            return 1;
        }
    }
}
