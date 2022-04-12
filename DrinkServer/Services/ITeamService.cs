using DrinkServer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinkServer.Services
{
    public interface ITeamService
    {
        Task<T> GetTeamVM<T>(List<int> Report_StroeIds, List<int> Warehouse_SupportIds, List<int> Process_StoreIds, List<int> UserIds) where T : TeamVM, new();
    }
}