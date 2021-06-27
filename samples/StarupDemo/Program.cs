using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarupDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /*
         * 1¡¢ConfigureWebHostDefaults
         * 2¡¢ConfigureHostConfiguration
         * 3¡¢ConfigureAppConfiguration
         * 4¡¢ConfigureServices
         * 5¡¢Startup.Configure ÖÐ¼ä¼þ
         */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(builder => { Console.WriteLine("ConfigureAppConfiguration"); })
                .ConfigureServices(_=>{ Console.WriteLine("ConfigureServices"); })
                .ConfigureHostConfiguration(_=>{ Console.WriteLine("ConfigureHostConfiguration"); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Console.WriteLine("ConfigureWebHostDefaults");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
