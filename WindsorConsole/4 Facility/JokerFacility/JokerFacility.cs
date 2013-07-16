using System.Collections.Generic;
using System.Linq;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.ModelBuilder;
using Castle.MicroKernel.Registration;

namespace WindsorConvention
{
    public class JokerFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(Component
                                .For<IJokePublisher, IJokeRegister>()
                                .ImplementedBy<JokerBroker>()
                                .DependsOn(new { listeners = new List<object>() })
                                .LifeStyle.Singleton);

            Kernel.ComponentModelBuilder.AddContributor(new JokerContributor());
        }
    }

    public class JokerContributor : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (model.Implementation
                .GetInterfaces()
                .Where(i => i.IsGenericType)
                .Select(i => i.GetGenericTypeDefinition())
                .Any(i => i == typeof(IJokeListener<>)) == false)
            {
                return;
            }

            var broker = kernel.Resolve<IJokeRegister>();
            model.Lifecycle.Add(new RegisterWithJoker(broker));
            model.Lifecycle.Add(new UnregisterWithJoker(broker));
        }
    }

    public struct UnregisterWithJoker : IDecommissionConcern
    {
        private readonly IJokeRegister _broker;

        public UnregisterWithJoker(IJokeRegister broker)
        {
            _broker = broker;
        }

        public void Apply(ComponentModel model, object component)
        {
            _broker.Unregister(component);
        }
    }

    public class RegisterWithJoker : ICommissionConcern
    {
        private readonly IJokeRegister _broker;

        public RegisterWithJoker(IJokeRegister broker)
        {
            _broker = broker;
        }

        public void Apply(ComponentModel model, object component)
        {
            _broker.Register(component);
        }
    }
}
