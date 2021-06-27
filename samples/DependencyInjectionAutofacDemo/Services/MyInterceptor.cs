using System;
using Castle.DynamicProxy;

namespace DependencyInjectionAutofacDemo.Services
{
    public class MyInterceptor:IInterceptor
    {
        /// <summary>
        /// 面向切面
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Interceptor Before,Method:{invocation.Method.Name}");
            // invocation.Proceed(); // 拦截
            Console.WriteLine($"Interceptor After,Method:{invocation.Method.Name}");
        }
    }
}