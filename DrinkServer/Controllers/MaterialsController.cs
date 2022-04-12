using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DrinkServer.Models;
using DrinkServer.Views.ViewModel;
using DrinkServer.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

namespace yavis_order.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MaterialsController : Controller
    {
        private readonly Yavis_OrderDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public MaterialsController(Yavis_OrderDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {

            //List<string> categorieslist = _context.MaterialCategories.Select(m => m.Name).Distinct().ToList();


            var yavis_OrderDbContext = _context.Materials.Include(m => m.ManufacturerSupplier).Include(m => m.MaterialCategory).Include(m => m.VendorSupplier);

            //var result = new MaterialCategoryViewModel()
            //{
            //    McategoryList = _context.MaterialCategories.ToList()
            //};
            //ViewBag.x = result;

            return View(await yavis_OrderDbContext.ToListAsync());

        }

        public async Task<IActionResult> Materials()
        {
            List<MaterialCategory> categorieslist = await _context.MaterialCategories.Include(m => m.Materials).ToListAsync();
            return View(categorieslist);

        }

        // GET: Materials/Details/5
        public async Task<IActionResult> Materials_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = new ListViewModel()
            {
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;
            var material = await _context.Materials
                .Include(m => m.ManufacturerSupplier)
                .Include(m => m.MaterialCategory)
                .Include(m => m.VendorSupplier)
                .Include(m => m.MaterialMappings)
                .ThenInclude(m => m.Warehouses)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }


        //public IActionResult Materials_Create()
        //{
        //    ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategories, "Id", "Name");
        //    ViewData["ManufacturerSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
        //    ViewData["VendorSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
        //    //ViewData["Warehouse"] = new SelectList(_context.Warehouses, "Id", "Name");

        //    var result = new ListViewModel()
        //    {
        //        WarehouseList = _context.Warehouses.ToList()
        //    };
        //    ViewBag.x = result;
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Materials_Create([FromForm] MaterialCreateViewModel materialCreate, int[] MaterialArray)
        //{
        //    var result = new ListViewModel()
        //    {
        //        StoreList = _context.Stores.ToList(),
        //        WarehouseList = _context.Warehouses.ToList()
        //    };
        //    ViewBag.x = result;
        //    string Pictures = UploadFile(materialCreate);
        //    if (ModelState.IsValid)
        //    {
        //        Material materials = new Material()
        //        {
        //            Sku = materialCreate.Sku,
        //            Brand = materialCreate.Brand,
        //            Unit = materialCreate.Unit,
        //            Podescription = materialCreate.Podescription,
        //            Picture = Pictures,
        //            Availability = materialCreate.Availability,
        //            MaterialCategoryId = materialCreate.MaterialCategoryId,
        //            VendorSupplierId = materialCreate.VendorSupplierId,
        //            ManufacturerSupplierId = materialCreate.VendorSupplierId,
        //            DateTime = materialCreate.DateTime,
        //            EnglishName = materialCreate.EnglishName,
        //            ChineseName = materialCreate.ChineseName,

        //        };
        //            _context.Add(materials);
        //            await _context.SaveChangesAsync();

        //            foreach (int item in MaterialArray)
        //            {
        //                MaterialMapping materialMapping = new MaterialMapping()
        //                {
        //                    MaterialId = materials.Id,
        //                    WarehouseId = item

        //                };
        //                await _context.MaterialMappings.AddAsync(materialMapping);
        //            }
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Materials));
        //    }
        //    ViewBag.IsValid = ModelState.IsValid;
        //    return View(materialCreate);
        //}

        public IActionResult Materials_Create()
        {
            ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategories, "Id", "Name");
            ViewData["ManufacturerSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            ViewData["VendorSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            //ViewData["Warehouse"] = new SelectList(_context.Warehouses, "Id", "Name");



            var result = new ListViewModel()
            {
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Materials_Create([FromForm] MaterialCreateViewModel materialCreate, int[] MaterialArray)
        {
            if (_context.Materials.Any(s => s.Sku == materialCreate.Sku))
            {
                var result = new ListViewModel()
                {
                    WarehouseList = _context.Warehouses.ToList()
                };
                ViewBag.x = result;
                //重複
                ViewBag.IsValid = ModelState.IsValid;
                ViewBag.ErrorMsg = "Sku is Aready exist.";
                ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategories, "Id", "Name");
                ViewData["ManufacturerSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
                ViewData["VendorSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
                return View(materialCreate);
            }
            else
            {

                string Pictures = UploadFile(materialCreate);
                Material materials = new Material()
                {
                    Sku = materialCreate.Sku,
                    Brand = materialCreate.Brand,
                    Unit = materialCreate.Unit,
                    Podescription = materialCreate.Podescription,
                    Picture = Pictures,
                    Availability = materialCreate.Availability,
                    MaterialCategoryId = materialCreate.MaterialCategoryId,
                    VendorSupplierId = materialCreate.VendorSupplierId,
                    ManufacturerSupplierId = materialCreate.VendorSupplierId,
                    DateTime = materialCreate.DateTime,
                    EnglishName = materialCreate.EnglishName,
                    ChineseName = materialCreate.ChineseName,

                };

                _context.Add(materials);

                await _context.SaveChangesAsync();

                foreach (int item in MaterialArray)
                {
                    MaterialMapping materialMapping = new MaterialMapping()
                    {
                        MaterialId = materials.Id,
                        WarehouseId = item

                    };
                    await _context.MaterialMappings.AddAsync(materialMapping);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Materials));
                }

            }
            ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategories, "Id", "Name");
            ViewData["ManufacturerSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            ViewData["VendorSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");
            return RedirectToAction(nameof(Materials));
        }

        private string UploadFile(MaterialCreateViewModel materialCreate)
        {
            string fileName = null;
            if (materialCreate.Picture != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + materialCreate.Picture.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    materialCreate.Picture.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Materials_Edit(int? id, MaterialCreateViewModel materialCreate)
        {
            string Pictures = UploadFile(materialCreate);
            Material materials = new Material()
            {
                Id = materialCreate.Id,
                Sku = materialCreate.Sku,
                Brand = materialCreate.Brand,
                Unit = materialCreate.Unit,
                Podescription = materialCreate.Podescription,
                Picture = Pictures,
                Availability = materialCreate.Availability,
                MaterialCategoryId = materialCreate.MaterialCategoryId,
                VendorSupplierId = materialCreate.VendorSupplierId,
                ManufacturerSupplierId = materialCreate.VendorSupplierId,
                DateTime = materialCreate.DateTime,
                EnglishName = materialCreate.EnglishName,
                ChineseName = materialCreate.ChineseName,

            };
            if (id == null)
            {
                return NotFound();
            }


            var result = new ListViewModel()
            {
                WarehouseList = _context.Warehouses.ToList()
            };
            ViewBag.x = result;
            var material = await _context.Materials.Include(m => m.MaterialMappings).SingleOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", material.ManufacturerSupplierId);
            ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategories, "Id", "Name", material.MaterialCategoryId);
            ViewData["VendorSupplierId"] = new SelectList(_context.Suppliers, "Id", "Name", material.VendorSupplierId);
            ViewBag.CheckWarehouseList = material.MaterialMappings.Select(map => map.WarehouseId.Value).ToList();
            return View(material);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Materials_Edit(int id, [FromForm] MaterialCreateViewModel materialCreate, int[] MaterialArray)
        {
            string Pictures = UploadFile(materialCreate);
            Material materials = new Material()
            {
                Id = materialCreate.Id,
                Sku = materialCreate.Sku,
                Brand = materialCreate.Brand,
                Unit = materialCreate.Unit,
                Podescription = materialCreate.Podescription,
                Picture = Pictures,
                Availability = materialCreate.Availability,
                MaterialCategoryId = materialCreate.MaterialCategoryId,
                VendorSupplierId = materialCreate.VendorSupplierId,
                ManufacturerSupplierId = materialCreate.VendorSupplierId,
                DateTime = materialCreate.DateTime,
                EnglishName = materialCreate.EnglishName,
                ChineseName = materialCreate.ChineseName,

            };

            if (ModelState.IsValid)
            {
                //string Pictures = UploadFile(materialCreate);
                //materials.Picture = Pictures;

                _context.Update(materials);
                var mms = _context.MaterialMappings.Where(p => p.MaterialId == materialCreate.Id).AsEnumerable();
                _context.MaterialMappings.RemoveRange(mms);

                foreach (int item in MaterialArray)
                {
                    MaterialMapping materialMapping = new MaterialMapping()
                    {
                        MaterialId = materials.Id,
                        WarehouseId = item

                    };
                    await _context.MaterialMappings.AddAsync(materialMapping);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Materials_Details), new { id = id });
                ViewData["ManufacturerSupplierId"] = new SelectList(_context.Suppliers, "Id", "Id", materials.ManufacturerSupplierId);
                ViewData["MaterialCategoryId"] = new SelectList(_context.MaterialCategories, "Id", "Id", materials.MaterialCategoryId);
                ViewData["VendorSupplierId"] = new SelectList(_context.Suppliers, "Id", "Id", materials.VendorSupplierId);
            }


            return View();
        }

        // GET: Materials/Delete/5
        public async Task<IActionResult> Materials_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.ManufacturerSupplier)
                .Include(m => m.MaterialCategory)
                .Include(m => m.VendorSupplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Materials_Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Materials));
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.Id == id);
        }
        //[AcceptVerbs("Get", "Post")]
        //public IActionResult VerifySku(string Sku)
        //{
        //    if (_context.Materials.Any(p => p.Sku == Sku))
        //    {
        //        return Json($"{Sku} is already in use");
        //    }
        //    return Json(true);

        //}
    }
}
