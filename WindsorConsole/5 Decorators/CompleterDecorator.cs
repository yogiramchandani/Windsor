using System;
using System.Collections.Generic;

namespace WindsorConvention
{
    public class CompleterDecorator : IMakeCrappyJokes
    {
        private readonly IMakeCrappyJokes _toDecorate;

        public CompleterDecorator(IMakeCrappyJokes toDecorate)
        {
            _toDecorate = toDecorate;
        }

        public string[] TellAJoke()
        {
            var lines = _toDecorate.TellAJoke();
            lines[0] += ", they haven't had any Gigs yet.";
            lines[1] += " ... that was the joke.";
            return lines;
        }
    }
}