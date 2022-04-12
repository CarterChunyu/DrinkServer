using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;

namespace yavis_order.Controllers
{
   
    public class PartialViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
