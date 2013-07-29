using System;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WindsorConvention
{
    public class DelegateFactoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(
                Component.For<ISimpleMessenger>().ImplementedBy<SimpleMessenger>().LifestyleTransient(),
                Component.For<Func<ISimpleMessenger>>().AsFactory());
            container.Register(
                Component.For<IMakeCrappyJokes>().ImplementedBy<DelegateComedian>().LifestyleTransient());
        }
    }
}
