using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Data;
using DrinkServer.Models;
using DrinkServer.ViewModels;

namespace DrinkServer.Services
{
    public class UserService : IUserService
    {
        private readonly DrinkContext _context;
        public UserService(DrinkContext context)
        {
            _context = context;
        }
        public T GetUserVM<T>(int? teamId) where T : UserVM, new()
        {
            List<TeamCheckVM> teamCheckVMs = new List<TeamCheckVM>();
            foreach (var item in _context.Teams)
            {
                TeamCheckVM teamCheckVM = new TeamCheckVM()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Flag = item.Id == item.Id ? true : false
                };
                teamCheckVMs.Add(teamCheckVM);
            }
            T t = new T()
            {
                TeamCheckVMs = teamCheckVMs
            };
            return t;
        }
    }
}
