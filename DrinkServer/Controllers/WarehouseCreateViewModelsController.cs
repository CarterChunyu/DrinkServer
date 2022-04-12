using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinkServer.Helpers;
using DrinkServer.Models;
using DrinkServer.Views.ViewModel;
using DrinkServer.Data;
using Microsoft.AspNetCore.Authorization;


namespace yavis_order.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WarehouseCreateViewModelsController : Controller
    {
        private readonly Yavis_OrderDbContext _context;

        public WarehouseCreateViewModelsController(Yavis_OrderDbContext context)
        {
            _context = context;
        }

        // GET: WarehouseCreateViewModels
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            int skipCount = (pageIndex - 1) * 3;
            var yavis_OrderDbContext = _context.Warehouses.Skip(skipCount).Take(3).Include(s => s.Location);
            ViewBag.TotalDataCount = Convert.ToDecimal(_context.Warehouses.Count());
            return View(await yavis_OrderDbContext.ToListAsync());


        }

        public async Task<IActionResult> Warehouses(int page = 1)
        {

            int page_count = 3;
            var yavis_OrderDbContext = _context.Warehouses.Include(s => s.Location);
            int pages = yavis_OrderDbContext.GetPages(page_count);
            IEnumerable<Warehouse> model = yavis_OrderDbContext.GetPages(page_count, page);
            ViewData["pages"] = pages;
            ViewData["nowpage"] = page;
            return View(model.ToList());

        }

        // GET: WarehouseCreateViewModels/Details/5
        public IActionResult Warehouses_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //拿回warehose
            Warehouse warehouse = _context.Warehouses.Where(row => row.Id == id).SingleOrDefault();
            if (warehouse == null)
            {
                return NotFound();
            }
            //拿回OrdersPlaceMapping
            List<OrdersPlaceMapping> ordersPlaceMappings = _context.OrdersPlaceMappings.Where(row => row.OrderToId == id).ToList();
            if (ordersPlaceMappings == null)
            {
                return NotFound();
            }

            //把warehose換成WarehouseCreateViewModel
            WarehouseCreateViewModel vm = new WarehouseCreateViewModel()
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Note = warehouse.Note,
                Code = warehouse.Code,
                Status = warehouse.Status
            };

            //把OrdersPlaceMapping變成兩個ID陣列
            int[] StoreIdArray = ordersPlaceMappings.Where(row => row.OrderFromTable == "Store").Select(row => row.OrderFromId).ToArray();
            int[] WarehouseIdArray = ordersPlaceMappings.Where(row => row.OrderFromTable == "Warehouse").Select(row => row.OrderFromId).ToArray();
            ViewBag.StoreIdArray = StoreIdArray;
            ViewBag.WarehouseIdArray = WarehouseIdArray;

            var result = new ListViewModel()
            {
                StoreList = _context.Stores.ToList(),
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;
            return View(vm);
        }

        // GET: WarehouseCreateViewModels/Create
        public IActionResult Warehouses_Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            var result = new ListViewModel()
            {
                StoreList = _context.Stores.ToList(),
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Warehouses_Create([FromForm] WarehouseCreateViewModel WarehouseTable, int[] StoreIdArray, int[] WarehouseIdArray)
        {
           
                var result = new ListViewModel()
                {
                    StoreList = _context.Stores.ToList(),
                    WarehouseList = _context.Warehouses.ToList()
                };
                ViewBag.x = result;
             if (ModelState.IsValid)
              {
                    Warehouse warehouse = new Warehouse()
                {
                    Code = (long)WarehouseTable.Code,
                    Name = WarehouseTable.Name,
                    Note = WarehouseTable.Note,
                    Status = WarehouseTable.Status,
                    LocationId = 1
                };
                if (_context.Warehouses.Any(s => s.Name == WarehouseTable.Name))
                {
                    ViewBag.ErrorMsg = "Warehouse Name is Aready exist.";
                    return View();
                }
                else
                {
                    await _context.Warehouses.AddAsync(warehouse);
                    await _context.SaveChangesAsync();

                    foreach (int item in StoreIdArray)
                    {
                        OrdersPlaceMapping ordersPlaceMapping = new OrdersPlaceMapping()
                        {
                            OrderToTable = "Warehouse",
                            OrderToId = warehouse.Id,
                            OrderFromTable = "Store",
                            OrderFromId = item
                        };
                        await _context.OrdersPlaceMappings.AddAsync(ordersPlaceMapping);

                    }
                    foreach (int item in WarehouseIdArray)
                    {
                        OrdersPlaceMapping ordersPlaceMapping = new OrdersPlaceMapping()
                        {
                            OrderToTable = "Warehouse",
                            OrderToId = warehouse.Id,
                            //永遠新增的warehouse
                            OrderFromTable = "Warehouse",
                            OrderFromId = item
                        };
                        await _context.OrdersPlaceMappings.AddAsync(ordersPlaceMapping);
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Warehouses));
                }
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View(WarehouseTable);
        }

        // GET: WarehouseCreateViewModels/Edit/5
        public async Task<IActionResult> Warehouses_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //拿回warehose
            Warehouse warehouse = await _context.Warehouses.Where(row => row.Id == id).SingleOrDefaultAsync();
            if (warehouse == null)
            {
                return NotFound();
            }
            //拿回OrdersPlaceMapping
            List<OrdersPlaceMapping> ordersPlaceMappings = await _context.OrdersPlaceMappings.Where(row => row.OrderToId == id).ToListAsync();
            if (ordersPlaceMappings == null)
            {
                return NotFound();
            }

            //把warehose換成WarehouseCreateViewModel
            WarehouseCreateViewModel vm = new WarehouseCreateViewModel()
            {
                Id = warehouse.Id,
                Name = warehouse.Name,
                Note = warehouse.Note,
                Code = warehouse.Code,
                Status = warehouse.Status
            };

            //把OrdersPlaceMapping變成兩個ID陣列
            int[] StoreIdArray = ordersPlaceMappings.Where(row => row.OrderFromTable == "Store").Select(row => row.OrderFromId).ToArray();
            int[] WarehouseIdArray = ordersPlaceMappings.Where(row => row.OrderFromTable == "Warehouse").Select(row => row.OrderFromId).ToArray();
            ViewBag.StoreIdArray = StoreIdArray;
            ViewBag.WarehouseIdArray = WarehouseIdArray;

            var result = new ListViewModel()
            {
                StoreList = _context.Stores.ToList(),
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Warehouses_Edit(int? Id, [FromForm] WarehouseCreateViewModel WarehouseTable, int[] StoreIdArray, int[] WarehouseIdArray)
        {

                Warehouse warehouse = await _context.Warehouses.Where(row => row.Id == WarehouseTable.Id).SingleOrDefaultAsync();
                if (warehouse == null)
                {
                    return NotFound();
                }
                warehouse.Id = WarehouseTable.Id;
                warehouse.Code = (long)WarehouseTable.Code;
                warehouse.Name = WarehouseTable.Name;
                warehouse.Note = WarehouseTable.Note;
                warehouse.Status = WarehouseTable.Status;


                List<OrdersPlaceMapping> ordersPlaceMappings = await _context.OrdersPlaceMappings.Where(row => row.OrderToId == WarehouseTable.Id).ToListAsync();
                List<OrdersPlaceMapping> storeMappingList = ordersPlaceMappings.Where(row => row.OrderFromTable == "Store").ToList();
                List<OrdersPlaceMapping> warehouseMappingList = ordersPlaceMappings.Where(row => row.OrderFromTable == "Warehouse").ToList();

                //刪掉沒有打勾的
                foreach (OrdersPlaceMapping item in storeMappingList)
                {
                    if (Array.IndexOf(StoreIdArray, item.OrderFromId) == -1)
                    {
                        _context.OrdersPlaceMappings.Remove(item);
                    }
                }

                //新增不在DB的
                foreach (int storeId in StoreIdArray)
                {
                    //該筆資料是不存在
                    if (storeMappingList.Any(row => row.OrderFromId == storeId) == false)
                    {
                        OrdersPlaceMapping ordersPlaceMapping = new OrdersPlaceMapping()
                        {
                            OrderToTable = "Warehouse",
                            OrderToId = warehouse.Id,
                            OrderFromTable = "Store",
                            OrderFromId = storeId
                        };
                        await _context.OrdersPlaceMappings.AddAsync(ordersPlaceMapping);
                    }
                }

                //刪掉沒有打勾的
                foreach (OrdersPlaceMapping item in warehouseMappingList)
                {
                    if (Array.IndexOf(WarehouseIdArray, item.OrderFromId) == -1)
                    {
                        _context.OrdersPlaceMappings.Remove(item);
                    }
                }

                //新增不在DB的
                foreach (int warehouseId in WarehouseIdArray)
                {
                    //該筆資料是不存在
                    if (warehouseMappingList.Any(row => row.OrderFromId == warehouseId) == false)
                    {
                        OrdersPlaceMapping ordersPlaceMapping = new OrdersPlaceMapping()
                        {
                            OrderToTable = "Warehouse",
                            OrderToId = warehouse.Id,
                            OrderFromTable = "Warehouse",
                            OrderFromId = warehouseId
                        };
                        await _context.OrdersPlaceMappings.AddAsync(ordersPlaceMapping);
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Warehouses_Details), new { Id = Id });
        }
        [AcceptVerbs("Get","Post")]
        public IActionResult isCodeNull(long Code)
        {
            if (string.IsNullOrEmpty(Code.ToString()))
            {
                return Json(false);
            }
            return Json(true);
        }


        // GET: WarehouseCreateViewModels/Delete/5
        public IActionResult Warehouses_Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var warehouseCreateViewModel = await _context.WarehouseCreateViewModel
            //    .Include(w => w.Location)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (warehouseCreateViewModel == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: WarehouseCreateViewModels/Delete/5
        [HttpPost, ActionName("Warehouses_Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //var warehouseCreateViewModel = await _context.WarehouseCreateViewModel.FindAsync(id);
            //_context.WarehouseCreateViewModel.Remove(warehouseCreateViewModel);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Warehouses));
        }

    }
}
