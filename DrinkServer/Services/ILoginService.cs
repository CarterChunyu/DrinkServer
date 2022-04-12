using DrinkServer.ViewModels;
using System.Threading.Tasks;

namespace DrinkServer.Services
{
    public interface ILoginService
    {
        string GetHash(string text);
        Task SetClaims(LoginAuthorizeVM vm);
        Task<LoginAuthorizeVM> SetSessionVM(int userId, int teamId, string userName);
    }
}