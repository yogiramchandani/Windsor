using System;

namespace WindsorConvention
{
    public class DelegateComedian : IMakeCrappyJokes
    {
        private readonly Func<ISimpleMessenger> _timedFactory;

        public DelegateComedian(Func<ISimpleMessenger> timedFactory)
        {
            _timedFactory = timedFactory;
        }

        public string[] TellAJoke()
        {
            var timer = _timedFactory();
            var message = timer.GetMessage(DateTime.UtcNow);

            return new[]{message, "Why are some jokes so painfull ? ", "Must be the punchline, ta da tsss"};
        }
    }
}
