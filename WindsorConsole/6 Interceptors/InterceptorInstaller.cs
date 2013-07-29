using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WindsorConvention
{
    public class InterceptorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ConsoleInterceptor>().LifeStyle.Transient);
            container.Register(
                Component.For<IMakeCrappyJokes>().ImplementedBy<WaitingToBeInterceptedComedian>().Interceptors(InterceptorReference.ForType<ConsoleInterceptor>()).Anywhere);
        }
    }
}
