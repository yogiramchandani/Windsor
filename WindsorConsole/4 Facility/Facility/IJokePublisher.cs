namespace WindsorConvention
{
    public interface IJokePublisher
    {
        void Publish<T>(T message);
    }
}