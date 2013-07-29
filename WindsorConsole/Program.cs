using System;
using Castle.Windsor;

namespace WindsorConvention
{
    public class Program
    {
        static void Main()
        {
            // 1. Register
            //using (IWindsorContainer container = new WindsorContainer().Install(new AppSettingsConventionInstaller()))
            //using (IWindsorContainer container = new WindsorContainer().Install(new ArrayResolverInstaller()))
            //using (IWindsorContainer container = new WindsorContainer().Install(new LoggingInstaller()))
            //using (IWindsorContainer container = new WindsorContainer().Install(new FacilityInstaller()))
            //using (IWindsorContainer container = new WindsorContainer().Install(new DecoratorInstaller()))
            //using (IWindsorContainer container = new WindsorContainer().Install(new InterceptorInstaller()))
            //using (IWindsorContainer container = new WindsorContainer().Install(new FactoryInstaller()))
            using (IWindsorContainer container = new WindsorContainer().Install(new DelegateFactoryInstaller()))
            {
                do
                {
                    SimulateNewRequest(container);
                } while (Console.ReadKey().Key != ConsoleKey.C);
            }
        }

        private static void SimulateNewRequest(IWindsorContainer container)
        {
            // 2. Resolve
            var joker = container.Resolve<IMakeCrappyJokes>();

            string[] aJoke = joker.TellAJoke();
            Console.WriteLine("Joker HashCode : {0}", joker.GetHashCode());
            foreach (var joke in aJoke)
            {
                Console.WriteLine(joke);
            }

            Console.WriteLine();
            Console.WriteLine("---------Refresh----------");
            Console.WriteLine();

            // 3. Release
            container.Release(joker);
        }
    }
}
