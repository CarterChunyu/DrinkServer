
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using DrinkServer.Models;
using DrinkServer.ViewModels;
using DrinkServer.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace DrinkServer.Services
{
    public class LoginService : ILoginService
    {
        private readonly string salt = "Salt";
        private readonly DrinkContext _context;
        private readonly IHttpContextAccessor _accessor;
        public LoginService(DrinkContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public string GetHash(string text)
        {
            using (SHA256Managed sHA256Managed = new SHA256Managed())
            {
                byte[] textByte = Encoding.UTF8.GetBytes($"{text}{salt}");
                byte[] hashBytes = sHA256Managed.ComputeHash(textByte);
                string hash = Convert.ToBase64String(hashBytes);
                return hash;
            }
        }
        public async Task<LoginAuthorizeVM> SetSessionVM(int userId, int teamId, string userName)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == teamId);
            LoginAuthorizeVM loginAuthorizeVM = new LoginAuthorizeVM(userId, teamId, userName);
            if (team.Name == "adminteam")
            {
                loginAuthorizeVM.LookInventory = true;
                loginAuthorizeVM.LookEntities = true;
                loginAuthorizeVM.LookAdmin = true;
                loginAuthorizeVM.LookReports = true;
                loginAuthorizeVM.LookOrders_Place = true;
                loginAuthorizeVM.LookOrders_Proccess = true;
            }
            if (_context.Teams_PlaceOrders.Any(p => p.TeamId == teamId))
                loginAuthorizeVM.LookOrders_Place = true;
            if (_context.Teams_ProcessOrders.Any(p => p.TeamId == teamId))
                loginAuthorizeVM.LookOrders_Proccess = true;
            if (_context.Team_Report_Stores.Any(p => p.TeamId == teamId))
                loginAuthorizeVM.LookReports = true;
            return loginAuthorizeVM;
        }

        public async Task SetClaims(LoginAuthorizeVM vm)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, "1234"));
            if (vm.LookAdmin)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            if (vm.LookReports)
                claims.Add(new Claim(ClaimTypes.Role, "Reports"));
            if (vm.LookOrders_Place)
                claims.Add(new Claim(ClaimTypes.Role, "Orders_Place"));
            if (vm.LookOrders_Proccess)
                claims.Add(new Claim(ClaimTypes.Role, "Orders_Proccess"));
            if (vm.LookOrders_Place || vm.LookOrders_Proccess)
                claims.Add(new Claim(ClaimTypes.Role, "Orders"));
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            await _accessor.HttpContext.SignInAsync(principal, new AuthenticationProperties()
            {
                IsPersistent = false
            });
        }
    }
}
