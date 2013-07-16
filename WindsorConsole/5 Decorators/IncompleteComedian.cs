namespace WindsorConvention
{
    public class IncompleteComedian : IMakeCrappyJokes
    {
        public string[] TellAJoke()
        {
            return new []{"There is a band called 1023MB", "What do you get when you cross a joke with a rhetorical question ?"};
        }
    }
}