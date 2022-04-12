using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinkServer.Models;
using DrinkServer.Views.ViewModel;
using System.Data;
using System.Data.SqlClient;
using DrinkServer.Data;

namespace yavis_order.Controllers

{
    public class OrdersPlaceMappingsController : Controller
    {
        private readonly Yavis_OrderDbContext _context;

        public OrdersPlaceMappingsController(Yavis_OrderDbContext context)
        {
            _context = context;
        }

        // GET: OrdersPlaceMappings
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrdersPlaceMappings.ToListAsync());
        }

        public IActionResult DynamicLoading()
        {

            return View();
        }

        public IActionResult PartialViewResult()
        {

            return PartialView("_StorePartial");
        }

        // GET: OrdersPlaceMappings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersPlaceMapping = await _context.OrdersPlaceMappings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersPlaceMapping == null)
            {
                return NotFound();
            }

            return View(ordersPlaceMapping);
        }

        // GET: OrdersPlaceMappings/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderToTable,OrderToId,OrderFromTable,OrderFromId")] OrdersPlaceMapping ordersPlaceMapping)
        {

            if (ModelState.IsValid)
            {
                _context.Add(ordersPlaceMapping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersPlaceMapping);
        }



        // GET: OrdersPlaceMappings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersPlaceMapping = await _context.OrdersPlaceMappings.FindAsync(id);
            if (ordersPlaceMapping == null)
            {
                return NotFound();
            }
            return View(ordersPlaceMapping);
        }

        // POST: OrdersPlaceMappings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderToTable,OrderToId,OrderFromTable,OrderFromId")] OrdersPlaceMapping ordersPlaceMapping)
        {
            if (id != ordersPlaceMapping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersPlaceMapping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersPlaceMappingExists(ordersPlaceMapping.Id))
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
            return View(ordersPlaceMapping);
        }

        // GET: OrdersPlaceMappings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersPlaceMapping = await _context.OrdersPlaceMappings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersPlaceMapping == null)
            {
                return NotFound();
            }

            return View(ordersPlaceMapping);
        }

        // POST: OrdersPlaceMappings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordersPlaceMapping = await _context.OrdersPlaceMappings.FindAsync(id);
            _context.OrdersPlaceMappings.Remove(ordersPlaceMapping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersPlaceMappingExists(int id)
        {
            return _context.OrdersPlaceMappings.Any(e => e.Id == id);
        }
    }
}
