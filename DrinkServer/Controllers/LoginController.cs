using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Data;
using DrinkServer.ViewModels;
using DrinkServer.Models;
using DrinkServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using DrinkServer.Helpers;
using Microsoft.AspNetCore.Authentication;

namespace DrinkServer.Controllers
{
    [Authorize()]
    public class LoginController : Controller
    {
        private readonly DrinkContext _context;
        private readonly ILoginService _loginService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(DrinkContext context, ILoginService loginService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _loginService = loginService;
            _httpContextAccessor = httpContextAccessor;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(loginVM);
            User user = await _context.Users.FirstOrDefaultAsync(p => p.LoginName == loginVM.Account
              && p.Password == _loginService.GetHash(loginVM.Password));
            if (user == null || !user.Status)
            {
                string DenialReason = user == null ? "Incorrect username or password" : "Status is Disable";
                ModelState.AddModelError("DenialReason", DenialReason);
                return View(loginVM);
            }

            int teamId = user.TeamId == null ? -1 : int.Parse(user.TeamId.ToString());
            // 儲存權限Session
            LoginAuthorizeVM loginAuthorizeVM = await _loginService.
                SetSessionVM(user.Id, teamId, user.DisplayName);
            await _loginService.SetClaims(loginAuthorizeVM);

            _httpContextAccessor.HttpContext.Session.SetObject("User", loginAuthorizeVM);
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            // return RedirectToAction("Details", "User",new {userId= user.Id});
            return RedirectToAction("HomePage");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _httpContextAccessor.HttpContext.Session.
                SetObject<LoginAuthorizeVM>("User", null);
            return RedirectToAction("Login", "Login");
        }


        [AllowAnonymous]
        public IActionResult NoPermission()
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            LoginAuthorizeVM loginAuthorizeVM = _httpContextAccessor.HttpContext.Session.GetObject<LoginAuthorizeVM>("User");
            User user = await _context.Users.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == loginAuthorizeVM.UserId);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> ProfileEdit(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
            ProfileUserVM profileUserVM = new ProfileUserVM()
            {
                UserId = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email
            };
            return View(profileUserVM);
        }
        [HttpPost]
        public async Task<IActionResult> ProfileEdit(ProfileUserVM profileUserVM)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.
                    FirstOrDefaultAsync(p => p.Id == profileUserVM.UserId);
                user.DisplayName = profileUserVM.DisplayName;
                user.Email = profileUserVM.Email;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile");
            }
            return View(profileUserVM);
        }
        [HttpGet]
        public async Task<IActionResult> ChagePassword(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
            ProfilePasswordVM profilePasswordVM = new ProfilePasswordVM()
            {
                UserId = user.Id,
                CurrentPasswrod = user.Password
            };
            return View(profilePasswordVM);
        }
        [HttpPost]
        public async Task<IActionResult> ChagePassword(ProfilePasswordVM profilePasswordVM)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == profilePasswordVM.UserId);
                user.Password = _loginService.GetHash(profilePasswordVM.NewPasswrod);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", "Login", new { id = user.Id });
            }
            return View(profilePasswordVM);
        }
        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsPsCorrect(string CurrentPasswrod)
        {
            LoginAuthorizeVM loginAuthorizeVM = _httpContextAccessor.HttpContext.Session.GetObject<LoginAuthorizeVM>("User");
            User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == loginAuthorizeVM.UserId);
            if (_loginService.GetHash(CurrentPasswrod) == user.Password)
                return Json(true);
            return Json($"Current Passwrod error");
        }

        public async Task<IActionResult> HomePage()
        {
            LoginAuthorizeVM loginAuthorizeVM =
                _httpContextAccessor.HttpContext.Session.GetObject<LoginAuthorizeVM>("User");
            User user = await _context.Users.Where(row => row.Id == loginAuthorizeVM.UserId).FirstOrDefaultAsync();
            return View(user);
        }
    }
}
