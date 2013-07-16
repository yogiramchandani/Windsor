using Castle.DynamicProxy;
using System;
using System.Linq;

namespace WindsorConvention
{
    public class ConsoleInterceptor : IInterceptor 
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before the action is performed.");
            invocation.Proceed();
            Console.WriteLine("After the action is performed.");
        }
    }
}
