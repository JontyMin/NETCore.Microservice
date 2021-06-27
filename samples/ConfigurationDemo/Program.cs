using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            //读取配置

            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(new Dictionary<string, string>()
            {
                {"key1", "value1"},
                {"key2", "value2"},
                {"section1:key3", "value3"},
                {"section2:key4", "section2:value1"},
                {"section2:key5", "section2:value2"},
            });

            IConfigurationRoot configurationRoot = builder.Build();

            Console.WriteLine(configurationRoot["key1"]);

            IConfigurationSection configurationSection = configurationRoot.GetSection("section2");
            Console.WriteLine(configurationSection["key4"]);
        }

    }
}
