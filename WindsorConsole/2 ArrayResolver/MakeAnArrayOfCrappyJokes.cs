using WindsorConvention;

namespace AppSettingsConvention
{
    public class MakeAnArrayOfCrappyJokes : IMakeCrappyJokes
    {
        private readonly ICrappyJokeLines[] _crappyJokeLines;

        public MakeAnArrayOfCrappyJokes(ICrappyJokeLines[] crappyJokeLines)
        {
            _crappyJokeLines = crappyJokeLines;
        }

        public string[] TellAJoke()
        {
            var lines = new string[_crappyJokeLines.Length];
            for (int i = 0; i < _crappyJokeLines.Length; i++)
            {
                lines[i] = _crappyJokeLines[i].GetLine();
            }
            return lines;
        }
    }
}