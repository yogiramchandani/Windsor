
using System;
using System.Collections.Generic;

namespace WindsorConvention
{
    public class StageJoker : IMakeCrappyJokes
    {
        private readonly IJokePublisher _publisher;
        private readonly IList<IAudience> _audience;

        public StageJoker(IJokePublisher publisher, IList<IAudience> audience)
        {
            _publisher = publisher;
            _audience = audience;
        }

        public string[] TellAJoke()
        {
            var jokes = new[] { "Alcohol & calculus don't mix. Never drink & derive.", 
                                "How do I set a laser printer to stun?", 
                                "Bad or missing mouse driver. Spank the cat? (Y/N)" };
            var random = new Random();
            
            _publisher.Publish(jokes[random.Next(0, 3)]);

            return jokes;
        }
    }
}
