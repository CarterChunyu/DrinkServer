using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Data;
using DrinkServer.ViewModels;
using DrinkServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using DrinkServer.Services;
using Microsoft.AspNetCore.Authorization;
using DrinkServer.Helpers;

namespace DrinkServer.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeamController : Controller
    {
        private readonly DrinkContext _context;
        private readonly ITeamService _teamService;
        private readonly INLogService _nlogService;
        public TeamController(DrinkContext context, ITeamService teamService, INLogService nLogService)
        {
            _context = context;
            _teamService = teamService;
            _nlogService = nLogService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            int page_count = 3;

            List<TeamIndexVM> teamIndexVMs = new List<TeamIndexVM>();
            foreach (var item in await _context.Teams.ToListAsync())
            {
                TeamIndexVM teamIndexVM = new TeamIndexVM()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Count = _context.Users.Where(p => p.TeamId == item.Id).Count()
                };
                teamIndexVMs.Add(teamIndexVM);
            }
            int pages = teamIndexVMs.GetPages(page_count);
            IEnumerable<TeamIndexVM> model = teamIndexVMs.GetPages(page_count, page);
            ViewData.Add(new KeyValuePair<string, object>("pages", pages));
            ViewData["nowpage"] = page;
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TeamVM teamCreateVM = await _teamService.
                GetTeamVM<TeamCreateVM>(new List<int>(), new List<int>(), new List<int>(), new List<int>());
            teamCreateVM.Warehouse_SupportVM = teamCreateVM.Warehouse_SupportVM
                .OrderBy(p => p.FromType).ThenBy(p => p.ToType).ToList();
            return View(teamCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create
            ([FromForm] TeamCreateVM teamCreateVM, int[] Report_StroeIds, int[] Warehouse_SupportIds, int[] Process_StoreIds)
        {
            if (ModelState.IsValid)
            {           
                IDbContextTransaction transaction = _context.Database.BeginTransaction();
                try
                {
                    Team team = new Team()
                    {
                        Name = teamCreateVM.Name
                    };

                    //_nlogService.NlogStart("Team Create");
                    //_nlogService.NlogObject(teamCreateVM);
                    //_nlogService.NlogEnd("Team Create");

                    await _context.Teams.AddAsync(team);
                    await _context.SaveChangesAsync();
                    int teamId = (await _context.Teams.AsNoTracking().OrderByDescending(p => p.Id)
                        .FirstOrDefaultAsync(p => p.Name == teamCreateVM.Name)).Id;

                    List<Teams_Report_Store> team_Report_Stores = new List<Teams_Report_Store>();
                    foreach (int Id in Report_StroeIds)
                    {
                        Teams_Report_Store team_Report_Store = new Teams_Report_Store()
                        {
                            TeamId = teamId,
                            StoreId = Id
                        };
                        team_Report_Stores.Add(team_Report_Store);
                    }
                    await _context.Team_Report_Stores.AddRangeAsync(team_Report_Stores);

                    List<Teams_PlaceOrder> teams_PlaceOrders = new List<Teams_PlaceOrder>();
                    foreach (int id in Warehouse_SupportIds)
                    {
                        Teams_PlaceOrder teams_PlaceOrder = new Teams_PlaceOrder()
                        {
                            TeamId = teamId,
                            OrdersPlaceMappingId = id
                        };
                        teams_PlaceOrders.Add(teams_PlaceOrder);
                    }
                    await _context.Teams_PlaceOrders.AddRangeAsync(teams_PlaceOrders);

                    List<Teams_ProcessOrder> teams_ProcessOrders = new List<Teams_ProcessOrder>();
                    foreach (int id in Process_StoreIds)
                    {
                        Teams_ProcessOrder teams_ProcessOrder = new Teams_ProcessOrder()
                        {
                            TeamId = teamId,
                            WarehouseId = id
                        };
                        teams_ProcessOrders.Add(teams_ProcessOrder);
                    }
                    await _context.Teams_ProcessOrders.AddRangeAsync(teams_ProcessOrders);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }

                catch (Exception ex)
                {
                    _nlogService.NlogEnd(ex.ToString());
                    await transaction.RollbackAsync();
                }
                finally
                {
                    await transaction.DisposeAsync();
                }

                return RedirectToAction("Index");
            }
            TeamCreateVM createView = await _teamService.GetTeamVM<TeamCreateVM>
                (Report_StroeIds.ToList(), Warehouse_SupportIds.ToList(), Process_StoreIds.ToList(), new List<int>());
            teamCreateVM.Name = createView.Name;
            return View(teamCreateVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);
            if (team.Name == "adminteam")
                return RedirectToAction("AdminDetails", new { id = id });

            List<int> Report_StroeIds = new List<int>();
            foreach (var item in _context.Team_Report_Stores.Where(p => p.TeamId == id))
            {
                Report_StroeIds.Add(item.StoreId);
            }
            List<int> Warehouse_SupportIds = new List<int>();
            foreach (var item in _context.Teams_PlaceOrders.Where(p => p.TeamId == id))
            {
                Warehouse_SupportIds.Add(item.OrdersPlaceMappingId);
            }
            List<int> Process_StoreIds = new List<int>();
            foreach (var item in _context.Teams_ProcessOrders.Where(p => p.TeamId == id))
            {
                Process_StoreIds.Add(item.WarehouseId);
            }
            List<int> UserIds = new List<int>();
            foreach (var item in _context.Users.Where(p => p.TeamId == id))
            {
                UserIds.Add(item.Id);
            }
            TeamEditVM teamVM = await _teamService.GetTeamVM<TeamEditVM>(Report_StroeIds, Warehouse_SupportIds,
                Process_StoreIds, UserIds);
            teamVM.Name = team.Name;
            teamVM.Id = team.Id;

            return View(teamVM);
        }
        [HttpGet]
        public async Task<IActionResult> AdminDetails(int id)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);
            List<User> users = await _context.Users.Where(p => p.TeamId == id).ToListAsync();
            TeamAdminVM teamAdminVM = new TeamAdminVM()
            {
                Id = id,
                Name = team.Name,
                Users = users
            };
            return View(teamAdminVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);

            List<int> Report_StroeIds = new List<int>();
            foreach (var item in _context.Team_Report_Stores.Where(p => p.TeamId == id))
            {
                Report_StroeIds.Add(item.StoreId);
            }
            List<int> Warehouse_SupportIds = new List<int>();
            foreach (var item in _context.Teams_PlaceOrders.Where(p => p.TeamId == id))
            {
                Warehouse_SupportIds.Add(item.OrdersPlaceMappingId);
            }
            List<int> Process_StoreIds = new List<int>();
            foreach (var item in _context.Teams_ProcessOrders.Where(p => p.TeamId == id))
            {
                Process_StoreIds.Add(item.WarehouseId);
            }
            List<int> UserIds = new List<int>();
            foreach (var item in _context.Users.Where(p => p.TeamId == id))
            {
                UserIds.Add(item.Id);
            }
            TeamEditVM teamVM = await _teamService.GetTeamVM<TeamEditVM>(Report_StroeIds, Warehouse_SupportIds,
                Process_StoreIds, UserIds);
            teamVM.Name = team.Name;
            teamVM.Id = team.Id;
            return View(teamVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit
           ([FromForm] TeamEditVM teamEditVM, int[] Report_StroeIds, int[] Warehouse_SupportIds, int[] Process_StoreIds)
        {
            if (ModelState.IsValid)
            {
                IDbContextTransaction transaction = _context.Database.BeginTransaction();
                try
                {
                    Team team = new Team()
                    {
                        Id = teamEditVM.Id,
                        Name = teamEditVM.Name
                    };

                    _context.Teams.Update(team);

                    List<Teams_Report_Store> team_Report_DBs = await _context.Team_Report_Stores.
                        Where(p => p.TeamId == teamEditVM.Id).ToListAsync();

                    // 移除原有在資料庫卻沒打勾的
                    foreach (var item in team_Report_DBs)
                    {
                        if (!Report_StroeIds.Contains(item.StoreId))
                            _context.Team_Report_Stores.Remove(item);
                    }

                    // 新增有打勾卻沒在資料庫的
                    List<Teams_Report_Store> addReport_Stores = new List<Teams_Report_Store>();
                    foreach (int Id in Report_StroeIds)
                    {
                        if (!team_Report_DBs.Any(p => p.StoreId == Id))
                        {
                            Teams_Report_Store team_Report_Store = new Teams_Report_Store()
                            {
                                TeamId = teamEditVM.Id,
                                StoreId = Id
                            };
                            addReport_Stores.Add(team_Report_Store);
                        }
                    }
                    await _context.Team_Report_Stores.AddRangeAsync(addReport_Stores);


                    // Teams_PlaceOrder
                    List<Teams_PlaceOrder> teams_PlaceOrderDBs = await _context.Teams_PlaceOrders.
                        Where(p => p.TeamId == teamEditVM.Id).ToListAsync();
                    // 移除原有在資料庫卻沒打勾的
                    foreach (var item in teams_PlaceOrderDBs)
                    {
                        if (!Warehouse_SupportIds.Contains(item.Id))
                            _context.Teams_PlaceOrders.Remove(item);
                    }
                    // 新增有打勾卻沒在資料庫的
                    List<Teams_PlaceOrder> addTeam_PlaceOrders = new List<Teams_PlaceOrder>();
                    foreach (int id in Warehouse_SupportIds)
                    {
                        if (!teams_PlaceOrderDBs.Any(p => p.OrdersPlaceMappingId == id))
                        {
                            Teams_PlaceOrder teams_PlaceOrder = new Teams_PlaceOrder()
                            {
                                TeamId = teamEditVM.Id,
                                OrdersPlaceMappingId = id
                            };
                            addTeam_PlaceOrders.Add(teams_PlaceOrder);
                        }
                    }
                    await _context.Teams_PlaceOrders.AddRangeAsync(addTeam_PlaceOrders);

                    // Teams_ProcessOrder
                    List<Teams_ProcessOrder> teams_ProcessOrderDBs = await _context.Teams_ProcessOrders.
                        Where(p => p.TeamId == teamEditVM.Id).ToListAsync();
                    // 移除原有在資料庫卻沒打勾的
                    foreach (var item in teams_ProcessOrderDBs)
                    {
                        if (!Process_StoreIds.Contains(item.WarehouseId))
                            _context.Teams_ProcessOrders.Remove(item);
                    }
                    // 新增有打勾卻沒在資料庫的
                    List<Teams_ProcessOrder> addteams_ProcessOrders = new List<Teams_ProcessOrder>();
                    foreach (int id in Process_StoreIds)
                    {
                        if (!teams_ProcessOrderDBs.Any(p => p.WarehouseId == id))
                        {
                            Teams_ProcessOrder teams_ProcessOrder = new Teams_ProcessOrder()
                            {
                                TeamId = teamEditVM.Id,
                                WarehouseId = id
                            };
                            addteams_ProcessOrders.Add(teams_ProcessOrder);
                        }
                    }
                    await _context.Teams_ProcessOrders.AddRangeAsync(addteams_ProcessOrders);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
                finally
                {
                    await transaction.DisposeAsync();
                }
                return RedirectToAction(nameof(Details),new { id= teamEditVM.Id });
                //return RedirectToAction(nameof(Details), new { Id = Id });
            }
            TeamEditVM editVM = await _teamService.GetTeamVM<TeamEditVM>
                (Report_StroeIds.ToList(), Warehouse_SupportIds.ToList(), Process_StoreIds.ToList(), new List<int>());
            editVM.Name = teamEditVM.Name;
            return View(editVM);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // 沒有任何使用主的Team才可以變成Disable
            if (!_context.Users.Any(p => p.TeamId == id))
            {
                IDbContextTransaction transaction = _context.Database.BeginTransaction();
                try
                {
                    var team = await _context.Teams.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    team.Status = false;
                    _context.Teams.Update(team);
                    var users = await _context.Users.Where(p => p.TeamId == id).ToListAsync();
                    foreach (var item in users)
                    {
                        item.TeamId = null;
                    }
                    _context.Users.UpdateRange(users);

                    var team_Report_Stores = _context.Team_Report_Stores.Where(p => p.TeamId == id).AsEnumerable();
                    _context.Team_Report_Stores.RemoveRange(team_Report_Stores);
                    var teams_PlaceOrders = _context.Teams_PlaceOrders.Where(p => p.TeamId == id).AsEnumerable();
                    _context.Teams_PlaceOrders.RemoveRange(teams_PlaceOrders);
                    var teams_ProcessOrders = _context.Teams_ProcessOrders.Where(p => p.TeamId == id).AsEnumerable();
                    _context.Teams_ProcessOrders.RemoveRange(teams_ProcessOrders);
                    _context.Teams.Remove(team);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
                finally
                {
                    await transaction.DisposeAsync();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> ManageMembers(int id)
        {
            Team team = await _context.Teams.FirstOrDefaultAsync(p => p.Id == id);

            ManageMeberVM manageMeberVM = new ManageMeberVM()
            {
                Id = id,
                Name = team.Name,
                UserVMs = new List<UserCheckVM>()
            };
            List<User> CheckedUsers = await _context.Users.Where(p => p.TeamId == id).ToListAsync();
            foreach (var item in _context.Users)
            {
                UserCheckVM userVM = new UserCheckVM()
                {
                    Id = item.Id,
                    Name = item.DisplayName,
                    Flag = CheckedUsers.Any(p => p.Id == item.Id) == true ? true : false
                };
                manageMeberVM.UserVMs.Add(userVM);
            }
            return View(manageMeberVM);
        }
        [HttpPost]
        public async Task<IActionResult> ManageMembers([FromForm] ManageMeberVM manageMeberVM, int[] MemberIds)
        {
            List<User> users = new List<User>();
            foreach (var item in _context.Users.Where(p => MemberIds.Contains(p.Id)))
            {
                item.TeamId = manageMeberVM.Id;
                users.Add(item);
            }
            _context.Users.UpdateRange(users);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = manageMeberVM.Id });
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsNameExisted(string Name)
        {
            if (_context.Teams.Any(p => p.Name == Name))
                return Json($"{Name} is already in already existed");
            return Json(true);
        }
    }
}
