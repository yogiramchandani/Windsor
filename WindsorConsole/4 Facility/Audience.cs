using System;

namespace WindsorConvention
{
    public class Marc : IJokeListener<string>, IAudience
    {
        public void Handle(string joke)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0} just heard a joke: '{1}'", GetType().Name, joke);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}: Damn that was wierd", GetType().Name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Adrian : IJokeListener<string>, IAudience
    {
        public void Handle(string joke)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0} just heard a joke: '{1}'", GetType().Name, joke);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}: I think that was nice", GetType().Name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Ronny : IJokeListener<string>, IAudience
    {
        public void Handle(string joke)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0} just heard a joke: '{1}'", GetType().Name, joke);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0}: Yup, definitely wierd", GetType().Name);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }

    public interface IAudience{}
}
