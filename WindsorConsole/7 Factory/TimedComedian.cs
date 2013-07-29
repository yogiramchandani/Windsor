using System;

namespace WindsorConvention
{
    public class TimedComedian : IMakeCrappyJokes
    {
        private readonly ITimedFactory _timedFactory;

        public TimedComedian(ITimedFactory timedFactory)
        {
            _timedFactory = timedFactory;
        }

        public string[] TellAJoke()
        {
            var timer = _timedFactory.Create(DateTime.UtcNow);
            var message = timer.GetMessage();
            _timedFactory.Release(timer);

            return new[]{message, "Why are some jokes so painfull ? ", "Must be the punchline, ta da tsss"};
        }
    }
}
