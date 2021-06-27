using System;

namespace DependencyInjectionAutofacDemo.Services
{
    public interface IMyService
    {
        void ShowCode();
    }

    public class MyService : IMyService
    {
        public void ShowCode()
        {
            Console.WriteLine($"MyService.ShowCode:{GetHashCode()}");
        }
    }

    public class MyService2 : IMyService
    {
        public MyNameService NameService { get; set; }

        public void ShowCode()
        {
            Console.WriteLine($"MyService2.ShowCode:{GetHashCode()},NameService是否为空：{NameService == null}");
        }
    }

    public class MyNameService
    {
    }
}