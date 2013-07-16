namespace AppSettingsConvention
{
    public class CrappyJokeLine1 : ICrappyJokeLines
    {
        public string GetLine()
        {
            return "Knock, knock.";
        }
    }
    public class CrappyJokeLine2 : ICrappyJokeLines
    {
        public string GetLine()
        {
            return "Who’s there?";
        }
    }
    public class CrappyJokeLine3 : ICrappyJokeLines
    {
        public string GetLine()
        {
            return "very long pause….";
        }
    }

    public class CrappyJokeLine4 : ICrappyJokeLines
    {
        public string GetLine()
        {
            return "Java.";
        }
    }

    public class CrappyJokeLine5 : ICrappyJokeLines
    {
        public string GetLine()
        {
            return ":-o";
        }
    }
}