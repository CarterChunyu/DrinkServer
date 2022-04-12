using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Data;
using DrinkServer.Models;
using DrinkServer.ViewModels;
using DrinkServer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using DrinkServer.Helpers;

namespace DrinkServer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly DrinkContext _context;
        private readonly IUserService _userService;
        private readonly ILoginService _loginService;

        public UserController(DrinkContext context, IUserService userService, ILoginService loginService)
        {
            _context = context;
            _userService = userService;
            _loginService = loginService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            UserCreateVM userCreateVM = _userService.GetUserVM<UserCreateVM>(null);
            userCreateVM.Status = true;
            return View(userCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateVM userCreateVM)
        {
            bool flag = true;
            if (userCreateVM.Status && userCreateVM.TeamId == -1)
            {
                ModelState.AddModelError("ErrorMessage", "Status is disabled Required Team");
                flag = false;
            }
            if (ModelState.IsValid&&flag)
            {                                
                User user = new User()
                {
                    DisplayName = userCreateVM.DisplayName,
                    Email = userCreateVM.Email,
                    Status = userCreateVM.Status,
                    TeamId = userCreateVM.TeamId < 1 ? null : userCreateVM.TeamId,
                    Password = _loginService.GetHash((userCreateVM.Password)),
                    LoginName = userCreateVM.LoginName
                };
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
            UserCreateVM CreateVM = _userService.GetUserVM<UserCreateVM>(userCreateVM.TeamId);
            userCreateVM.TeamCheckVMs = CreateVM.TeamCheckVMs;
            return View(userCreateVM);
        }

        public IActionResult Index(int page = 1, bool status = true)
        {
            int page_count = 3;
            IEnumerable<User> users = _context.Users.Include(p => p.Team).Where(p => p.Status == status).AsEnumerable();
            int pages = users.GetPages(page_count);
            IEnumerable<User> model = users.GetPages(page_count, page).OrderBy(p => p.TeamId);
            ViewData.Add(new KeyValuePair<string, object>("pages", pages));
            ViewData["nowpage"] = page;
            ViewData["status"] = status;
            return View(model);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Details(int Id)
        {
            User user = await _context.Users.Include(p => p.Team).
                FirstOrDefaultAsync(p => p.Id == Id);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
            UserEditVM userEditVM = _userService.GetUserVM<UserEditVM>(user.TeamId);
            userEditVM.Id = user.Id;
            userEditVM.DisplayName = user.DisplayName;
            userEditVM.Password = user.Password;
            userEditVM.ConfirmPassword = user.Password;
            userEditVM.LoginName = user.LoginName;
            userEditVM.Email = user.Email;
            userEditVM.Status = user.Status;
            userEditVM.TeamId = user.TeamId;
            return View(userEditVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditVM userEditVM,int id)
        {
            User olduser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Id == userEditVM.Id);
            bool flag = true;
            if (userEditVM.Status && userEditVM.TeamId == -1)
            {
                ModelState.AddModelError("ErrorMessage", "Status is disabled Required Team");
                flag = false;
            }
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Id = userEditVM.Id,
                    DisplayName = userEditVM.DisplayName,
                    LoginName = userEditVM.LoginName,
                    Password = userEditVM.Password == olduser.Password ? olduser.Password : _loginService.GetHash(userEditVM.Password),
                    Email = userEditVM.Email,
                    Status = userEditVM.Status,
                    TeamId = userEditVM.TeamId
                };
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { Id = id });
            }
            UserEditVM EditVM = _userService.GetUserVM<UserEditVM>(userEditVM.TeamId);
            return View(EditVM);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == userId);
            user.Status = false;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsNameExisted(string LoginName)
        {
            if (_context.Users.Any(p => p.LoginName == LoginName))
            {
                return Json($"LoginName {LoginName} is already existed.");
            }
            return Json(true);
        }
        [HttpGet]
        public async Task<IActionResult> ChagePassword(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
            AdminChangePasswordVM output = new AdminChangePasswordVM()
            {
                UserId = user.Id
            };
            return View(output);
        }
        [HttpPost]
        public async Task<IActionResult> ChagePassword(AdminChangePasswordVM input)
        {
            
            //ProfilePasswordVM userVM = new ProfilePasswordVM();
            //userVM.UserId = id;
            //userVM.NewPasswrod = string.Empty;
            //userVM.ComparePasswrod = string.Empty;
            //userVM.CurrentPasswrod = string.Empty;

            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(p => p.Id == input.UserId);
                user.Password = _loginService.GetHash(input.NewPasswrod);
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "User", new { id = user.Id });
            }
            return View(input);
        }
    }
}
