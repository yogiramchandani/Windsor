namespace WindsorConvention
{
    public interface IJokeRegister
    {
        void Register(object listener);

        void Unregister(object listener);
    }
}