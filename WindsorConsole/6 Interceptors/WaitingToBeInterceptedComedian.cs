namespace WindsorConvention
{
    public class WaitingToBeInterceptedComedian : IMakeCrappyJokes
    {
        public string[] TellAJoke()
        {
            return new string[]{"Line 1", "Line 2"};
        }
    }
}