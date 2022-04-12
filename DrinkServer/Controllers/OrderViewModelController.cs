using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;
using DrinkServer.Views.ViewModel;
namespace yavis_order.Controllers
{
    public class OrderViewModelController : Controller
    {
        // GET: OrderViewModelController
        public ActionResult Index()
        {

            return View();
        }

        // GET: OrderViewModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderViewModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderViewModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderViewModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderViewModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderViewModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderViewModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
