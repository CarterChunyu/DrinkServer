namespace DrinkServer.Services
{
    public interface INLogService
    {
        void NlogEnd(string message);
        void NlogObject<T>(T t);
        void NlogStart(string message);
    }
}