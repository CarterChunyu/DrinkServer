using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinkServer.Models;
using DrinkServer.Data;
using Microsoft.AspNetCore.Authorization;

namespace yavis_order.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MaterialCategoriesController : Controller
    {
        private readonly Yavis_OrderDbContext _context;

        public MaterialCategoriesController(Yavis_OrderDbContext context)
        {
            _context = context;
        }

        // GET: MaterialCategories
        public async Task<IActionResult> MaterialCategory()
        {
            return View(await _context.MaterialCategories.Include(p=>p.Materials).ToListAsync());
        }

        // GET: MaterialCategories/Details/5
        public async Task<IActionResult> MaterialCategory_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialCategory = await _context.MaterialCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialCategory == null)
            {
                return NotFound();
            }

            return View(materialCategory);
        }

        // GET: MaterialCategories/Create
        public IActionResult MaterialCategory_Create()
        {
            return View();
        }

        // POST: MaterialCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MaterialCategory_Create([Bind("Id,Name,DateTime")] MaterialCategory materialCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MaterialCategory));
            }
            return View(materialCategory);
        }
        // GET: MaterialCategories/Edit/5
        public async Task<IActionResult> MaterialCategory_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialCategory = await _context.MaterialCategories.FindAsync(id);
            if (materialCategory == null)
            {
                return NotFound();
            }
            return View(materialCategory);
        }

        // POST: MaterialCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MaterialCategory_Edit(int id, [Bind("Id,Name,DateTime")] MaterialCategory materialCategory)
        {
            if (id != materialCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialCategoryExists(materialCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MaterialCategory));
            }
            return View(materialCategory);
        }

        // GET: MaterialCategories/Delete/5
        public async Task<IActionResult> MaterialCategory_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialCategory = await _context.MaterialCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materialCategory == null)
            {
                return NotFound();
            }

            return View(materialCategory);
        }

        // POST: MaterialCategories/Delete/5
        [HttpPost, ActionName("MaterialCategory_Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialCategory = await _context.MaterialCategories.FindAsync(id);
            _context.MaterialCategories.Remove(materialCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MaterialCategory));
        }

        private bool MaterialCategoryExists(int id)
        {
            return _context.MaterialCategories.Any(e => e.Id == id);
        }
    }
}
