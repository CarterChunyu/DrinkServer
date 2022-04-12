using DrinkServer.Data;
using DrinkServer.Helpers;
using DrinkServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yavis_order.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SuppliersController : Controller
    {
        private readonly Yavis_OrderDbContext _context;

        public SuppliersController(Yavis_OrderDbContext context)
        {
            _context = context;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {


            return View(await _context.Suppliers.ToListAsync());
        }

        public async Task<IActionResult> Suppliers(string Type, int page = 1)
        {

            IQueryable<Supplier> suppliers = _context.Suppliers;
            if (!string.IsNullOrEmpty(Type))
                suppliers = suppliers.Where(p => p.Type == Type);

            int page_count = 3;

            int pages = suppliers.ToList().GetPages(page_count);
            IEnumerable<Supplier> model = suppliers.OrderBy(p => p.Type.Length).GetPages(page_count, page);
            ViewData.Add(new KeyValuePair<string, object>("pages", pages));
            ViewData["nowpage"] = page;
            ViewData["Type"] = Type != null ? Type : string.Empty;
            return View(model);

        }


        // GET: Suppliers/Details/5
        public async Task<IActionResult> Suppliers_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // GET: Suppliers/Create
        public IActionResult Suppliers_Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Suppliers_Create([Bind("Id,Code,Name,Notes,Status,DateTime", "Type")] Supplier supplier )
        {

            if (ModelState.IsValid)
            {
                    if (_context.Suppliers.Any(s => s.Name == supplier.Name))
                    {
                        //重複
                        ViewBag.IsValid = ModelState.IsValid;

                        ViewBag.ErrorMsg = "Supplier Name is Aready exist.";
                        return View(supplier);
                    }
                    else
                    {
                        Supplier s = new Supplier()
                        {
                            Code = supplier.Code,
                            Name = supplier.Name,
                            Status = supplier.Status,
                            Notes = supplier.Notes,
                            DateTime = supplier.DateTime,
                            Type = supplier.Type
                        };
                        _context.Add(s);
                        //不重複
                        //_context.Add(supplier);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Suppliers));
                    }


                
                //await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Suppliers));
            }
            return View(supplier);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Code,Name,Notes,Status,DateTime,Type")] Supplier supplier )
        //{
        //    Supplier s = new Supplier()
        //    {
        //        Code = supplier.Code,
        //        Name = supplier.Name,
        //        Status = supplier.Status,
        //        Notes = supplier.Notes,
        //        DateTime = supplier.DateTime,
        //        Type = supplier.Type
        //    };

        //    await _context.SaveChangesAsync();

        //        return RedirectToAction(nameof(Index));


        //}


        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Suppliers_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Suppliers_Edit(int id, [Bind("Id,Code,Name,Type,Notes,Status,DateTime")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    try
                    {
                        _context.Update(supplier);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SupplierExists(supplier.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Suppliers_Details), new { Id = id });
                
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Suppliers_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Suppliers_Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Suppliers));
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}
