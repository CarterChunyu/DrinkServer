using DrinkServer.ViewModels;

namespace DrinkServer.Services
{
    public interface IUserService
    {
        T GetUserVM<T>(int? teamId) where T : UserVM, new();
    }
}