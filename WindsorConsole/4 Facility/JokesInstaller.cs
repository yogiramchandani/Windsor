using Castle.Core.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WindsorConvention
{
    public class JokesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ((IKernelInternal)container.Kernel).Logger = new ConsoleLogger();
            container.AddFacility<JokerFacility>();
            container.Kernel.Resolver.AddSubResolver(new ListResolver(container.Kernel, false));
            container.Register(Classes
                                .FromAssembly(GetType().Assembly)
                                .BasedOn<IAudience>().WithService.Base()
                                .Configure(c => c.Named(c.Implementation.Name)).LifestyleTransient());
            container.Register(Component.For<IMakeCrappyJokes>().ImplementedBy<StageJoker>().LifestyleSingleton());
        }
    }
}
