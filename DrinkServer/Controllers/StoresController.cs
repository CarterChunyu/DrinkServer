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
    public class StoresController : Controller
    {
        private readonly Yavis_OrderDbContext _context;

        public StoresController(Yavis_OrderDbContext context)
        {
            _context = context;
        }

        //GET: Stores
        public IActionResult Stores(int page = 1)
        {
            int page_count = 3;

            var result = new ListViewModel()
            {
                StoreList = _context.Stores.ToList(),
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;
            var yavis_OrderDbContext = _context.Stores.Include(s => s.Location);

            int pages = yavis_OrderDbContext.GetPages(page_count);
            IEnumerable<Store> model = yavis_OrderDbContext.GetPages(page_count, page);
            ViewData["pages"] = pages;
            ViewData["nowpage"] = page;
            return View(model.ToList());
        }

        public IActionResult Index2()
        {

            var result = new ListViewModel()
            {
                StoreList = _context.Stores.ToList(),
                WarehouseList = _context.Warehouses.ToList()
            };
            return View(result);

        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Stores_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // GET: Stores/Create
        public IActionResult Stores_Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, nameof(Location.Id), nameof(Location.Name));
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Stores_Create([Bind("Id,Code,Name,Note,Status,LocationId,CreateTime")] Store store)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        store.CreateTime = DateTime.Now;
        //        _context.Add(store);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Stores));
        //    }
        //    ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", store.LocationId);
        //    return View(store);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Stores_Create([Bind("Id,Code,Name,Note,Status,LocationId,CreateTime")] Store store)
        {
            if (ModelState.IsValid)
            {
                store.CreateTime = DateTime.Now;
                if (_context.Stores.Any(s => s.Name == store.Name))
                {
                    //重複
                    ViewBag.IsValid = ModelState.IsValid;
                    ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", store.LocationId);
                    ViewBag.ErrorMsg = "Store Name is Aready exist.";
                    return View(store);
                }
                else
                {
                    //不重複
                    _context.Add(store);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Stores));
                }
            }
            ViewBag.IsValid = ModelState.IsValid;
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", store.LocationId);
            return View(store);
        }


        // GET: Stores/Edit/5
        public async Task<IActionResult> Stores_Edit(int? id)
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, nameof(Location.Id), nameof(Location.Name));
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, nameof(Location.Id), nameof(Location.Name));
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Stores_Edit(int id, [Bind("Id,Code,Name,Note,Status,LocationId,CreateTime")] Store store)
        {
            //ViewData["LocationId"] = new SelectList(_context.Locations, nameof(Location.Id), nameof(Location.Name));
            if (id != store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreExists(store.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Stores_Details), new { id = id });
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name", store.LocationId);
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Stores_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .Include(s => s.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Stores_Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Stores));
        }

        private bool StoreExists(int id)
        {
            return _context.Stores.Any(e => e.Id == id);
        }
    }
}
