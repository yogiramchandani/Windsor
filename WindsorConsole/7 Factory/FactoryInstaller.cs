using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WindsorConvention
{
    public class FactoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(
                Component.For<ITimer>().ImplementedBy<Timer>().LifestyleTransient(),
                Component.For<ITimedFactory>().AsFactory());
            container.Register(
                Component.For<IMakeCrappyJokes>().ImplementedBy<TimedComedian>().LifestyleTransient());
        }
    }
}
