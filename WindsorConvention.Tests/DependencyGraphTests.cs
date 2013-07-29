using System;
using System.IO;
using Castle.Windsor;
using NUnit.Framework;
using WindsorConvention._7_Dependency_Graph;

namespace WindsorConvention.Tests
{
    [TestFixture]
    public class DependencyGraphTests
    {
        [Test]
        public void DependencyGraph_ForTheAppSettingsConventionInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new AppSettingsConventionInstaller());
            WriteDependencyToConsole(container);
        }

        [Test]
        public void DependencyGraph_ForTheArrayResolverInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new ArrayResolverInstaller());
            WriteDependencyToConsole(container);
        }
/*

        [Test]
        public void DependencyGraph_ForTheLoggingInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new LoggingInstaller());
            WriteDependencyToConsole(container);
        }
*/

        [Test]
        public void DependencyGraph_ForTheFacilityInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new FacilityInstaller());
            WriteDependencyToConsole(container);
        }

        /*[Test]
        public void DependencyGraph_ForTheDecoratorInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new DecoratorInstaller());
            WriteDependencyToConsole(container);
        }*/

        [Test]
        public void DependencyGraph_ForTheInterceptorInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new InterceptorInstaller());
            WriteDependencyToConsole(container);
        }

        [Test]
        public void DependencyGraph_ForTheFactoryInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new FactoryInstaller());
            WriteDependencyToConsole(container);
        }

        [Test]
        public void DependencyGraph_ForTheDelegateFactoryInstaller()
        {
            IWindsorContainer container = new WindsorContainer().Install(new DelegateFactoryInstaller());
            WriteDependencyToConsole(container);
        }

        private static void WriteDependencyToConsole(IWindsorContainer container)
        {
            var dependencyGraphWriter = new DependencyGraphWriter(container, Console.Out);
            dependencyGraphWriter.Output();
        }
    }
}
