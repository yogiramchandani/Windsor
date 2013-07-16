using System.Linq;

namespace WindsorConvention
{
    public class OnCompleteDecorator : IMakeCrappyJokes
    {
        private readonly IMakeCrappyJokes _toDecorate;

        public OnCompleteDecorator(IMakeCrappyJokes toDecorate)
        {
            _toDecorate = toDecorate;
        }

        public string[] TellAJoke()
        {
            string[] lines = _toDecorate.TellAJoke();
            string[] completionMessage = new[]{"", "Ok relax I think he's almost done."};
            lines = lines.Concat(completionMessage).ToArray();
            return lines;
        }
    }
}