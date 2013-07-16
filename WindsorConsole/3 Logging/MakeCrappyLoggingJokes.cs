using Castle.Core.Logging;

namespace WindsorConvention
{
    public class MakeCrappyLoggingJokes : IMakeCrappyJokes
    {
        // Property Injection
        public ILogger Logger { get; set; }

        public string[] TellAJoke()
        {
            Logger.Info("Stand back! the fat man's going to make a funny.");
            return new[] { "When your hammer is C++, everything begins to look like a thumb." };
        }
    }
}