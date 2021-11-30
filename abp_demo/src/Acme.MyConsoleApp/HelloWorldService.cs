using System;
using Volo.Abp.DependencyInjection;

namespace Acme.MyConsoleApp
{

    // 瞬时
    public class HelloWorldService : ITransientDependency
    {
        public void SayHello()
        {
            Console.WriteLine("\tHello World!");
        }
    }
}
