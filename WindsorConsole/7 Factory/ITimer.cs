using System;

namespace WindsorConvention
{
    public interface ITimer
    {
        string GetMessage();
    }

    public class Timer : ITimer
    {
        private readonly DateTime _currentDate;

        public Timer(DateTime startTime)
        {
            _currentDate = startTime;
        }

        public string GetMessage()
        {
            return string.Format("The current time {0}", _currentDate.TimeOfDay);
        }
    }
}