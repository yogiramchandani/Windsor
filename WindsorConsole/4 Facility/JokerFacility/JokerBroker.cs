using System.Collections.Generic;
using System.Linq;

namespace WindsorConvention
{
    public class JokerBroker : IJokePublisher, IJokeRegister
    {
        private readonly IList<object> _listeners;

        public JokerBroker(IList<object> listeners)
        {
            _listeners = listeners;
        }

        public void Register(object listener)
        {
            if (_listeners.Contains(listener))
            {
                return;
            }
            _listeners.Add(listener);
        }

        public void Unregister(object listener)
        {
            if (!_listeners.Contains(listener))
            {
                return;
            }
            _listeners.Remove(listener);
        }

        public void Publish<T>(T message)
        {
            _listeners
                .Select(x => x as IJokeListener<T>)
                .Where(x => x != null)
                .Each(x => x.Handle(message));
        }
    }
}
