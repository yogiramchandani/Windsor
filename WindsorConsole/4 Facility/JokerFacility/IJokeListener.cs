namespace WindsorConvention
{
    public interface IJokeListener<in T>
    {
        void Handle(T joke);
    }
}