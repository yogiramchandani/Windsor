
using System;

namespace WindsorConvention
{
    public interface ISimpleMessenger
    {
        string GetMessage(DateTime time);
    }

    public class SimpleMessenger : ISimpleMessenger
    {
        public string GetMessage(DateTime time)
        {
            return string.Format("The simple message {0}", time.ToString());
        }
    }
}