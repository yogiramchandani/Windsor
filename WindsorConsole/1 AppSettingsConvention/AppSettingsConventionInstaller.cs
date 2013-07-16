using System;
using System.Configuration;
using Castle.Core;
using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WindsorConvention;

namespace WindsorConvention
{
    public class AppSettingsConventionInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ((IKernelInternal)container.Kernel).Logger = new ConsoleLogger();
            container.Kernel.Resolver.AddSubResolver(new AppSettingsConvention());
            container.Register(Component.For<IMakeCrappyJokes>().ImplementedBy<Make2LinesOfCrappyJokes>().LifestyleSingleton());
        }
    }

    public class AppSettingsConvention : ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            return dependency.TargetType == typeof(string);
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            var appSettingsKey = dependency.DependencyKey;
            var s = ConfigurationManager.AppSettings[appSettingsKey];
            return Convert.ChangeType(s, dependency.TargetType);
        }
    }
}