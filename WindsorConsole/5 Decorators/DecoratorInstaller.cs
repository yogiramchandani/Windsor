using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WindsorConvention
{
    public class DecoratorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMakeCrappyJokes>().ImplementedBy<OnCompleteDecorator>(),
                Component.For<IMakeCrappyJokes>().ImplementedBy<CompleterDecorator>(),
                Component.For<IMakeCrappyJokes>().ImplementedBy<IncompleteComedian>());
        }
    }
}
