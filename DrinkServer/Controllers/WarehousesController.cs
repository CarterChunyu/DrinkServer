using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinkServer.Models;
using DrinkServer.Views.ViewModel;
using DrinkServer.Data;
using Microsoft.AspNetCore.Authorization;

namespace yavis_order.Controllers
{
    [Authorize(Roles ="Admin")]
    public class WarehousesController : Controller
    {
        private readonly Yavis_OrderDbContext _context;

        public WarehousesController(Yavis_OrderDbContext context)
        {
            _context = context;
        }

        // GET: Warehouses
        public async Task<IActionResult> Index()
        {
            var result = new ListViewModel()
            {
                StoreList = _context.Stores.ToList(),
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;
            var yavis_OrderDbContext = _context.Warehouses.Include(w => w.Location);
            return View(await yavis_OrderDbContext.ToListAsync());
        }

        // GET: Warehouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses
                .Include(w => w.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // GET: Warehouses/Create
        public IActionResult Create()
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

        // POST: Warehouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Name,Name1,Note,Status,LocationId,CreateTime")] TestVM testVM)
        {
            //if (ModelState.IsValid)
            //{

            //    _context.Add(warehouse);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            Warehouse warehouse = new Warehouse()
            {
                Code = testVM.Code,
                Name = testVM.Name,
                Note = testVM.Note,
                Status = testVM.Status,
                LocationId = testVM.LocationId
            };
            _context.Add(warehouse);
            await _context.SaveChangesAsync();
            int id = _context.Warehouses.OrderByDescending(p => p.Id).FirstOrDefault(p => p.Name == testVM.Name).Id;
            Console.WriteLine(id + "--------------------------------");
            string[] array = testVM.Name1.Split(",");
            foreach (var item in array)
            {
                /*
                  public string OrderToTable { get; set; }
        public int? OrderToId { get; set; }
        public string OrderFromTable { get; set; }
        public int? OrderFromId { get; set; }
                 */
                string[] ar = item.Split("-");
                OrdersPlaceMapping om = new OrdersPlaceMapping()
                {
                    OrderFromTable = "Warhouse",
                    OrderFromId = id,
                    OrderToTable = ar[1],
                    OrderToId = int.Parse(ar[0])
                };
                await _context.OrdersPlaceMappings.AddAsync(om);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", warehouse.LocationId);
            //return View(warehouse);
        }

        // GET: Warehouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", warehouse.LocationId);
            return View(warehouse);
        }

        // POST: Warehouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Note,Status,LocationId,CreateTime")] Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseExists(warehouse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", warehouse.LocationId);
            return View(warehouse);
        }

        // GET: Warehouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses
                .Include(w => w.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warehouse = await _context.Warehouses.FindAsync(id);
            _context.Warehouses.Remove(warehouse);
            await _context.SaveChangesAsync();
            return RedirectToAction("Warehouses", "WarehouseCreateViewModels");
        }

        private bool WarehouseExists(int id)
        {
            return _context.Warehouses.Any(e => e.Id == id);
        }
    }
}
