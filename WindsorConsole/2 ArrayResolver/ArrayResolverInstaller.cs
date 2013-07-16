using AppSettingsConvention;
using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WindsorConvention
{
    public class ArrayResolverInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ((IKernelInternal)container.Kernel).Logger = new ConsoleLogger();
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel, false));
            container.Register(Classes.FromThisAssembly().BasedOn<ICrappyJokeLines>().WithService.Base());

            //Classes.FromAssemblyInDirectory(new AssemblyFilter("bin")).InNamespace("Acme.Crm.Extensions")
            //Classes.FromAssemblyContaining<MyController>().Where( t=> Attribute.IsDefined(t, typeof(CacheAttribute)))
            //Classes.FromAssemblyNamed("Acme.Crm.Services").Pick()

            container.Register(Component.For<IMakeCrappyJokes>().ImplementedBy<MakeAnArrayOfCrappyJokes>().LifestyleSingleton());
        }
    }
}