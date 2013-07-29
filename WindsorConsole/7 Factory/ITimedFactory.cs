using System;

namespace WindsorConvention
{
    public interface ITimedFactory
    {
        ITimer Create(DateTime startTime);
        void Release(ITimer timer);
    }
}