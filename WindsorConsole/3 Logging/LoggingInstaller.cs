using System.Linq;
using Castle.Core;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.MicroKernel;
using Castle.MicroKernel.ModelBuilder;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WindsorConvention
{
    public class LoggingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.ComponentModelBuilder.AddContributor(new RequireLoggerProperties());
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            container.Register(Component.For<IMakeCrappyJokes>().ImplementedBy<MakeCrappyLoggingJokes>());

            ((IKernelInternal) container.Kernel).Logger = container.Resolve<ILogger>();
        }
    }

    public class RequireLoggerProperties : IContributeComponentModelConstruction
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            model.Properties
                .Where(p => p.Dependency.TargetType == typeof(ILogger))
                .All(p => p.Dependency.IsOptional = false);
        }
    }
}
