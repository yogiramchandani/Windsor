using WindsorConvention;

namespace WindsorConvention
{
    public class Make2LinesOfCrappyJokes : IMakeCrappyJokes
    {
        private readonly string _line1;
        private readonly string _line2;

        public Make2LinesOfCrappyJokes(string line1, string line2)
        {
            _line1 = line1;
            _line2 = line2;
        }

        public string[] TellAJoke()
        {
            return new[]{_line1, _line2};
        }
    }
}