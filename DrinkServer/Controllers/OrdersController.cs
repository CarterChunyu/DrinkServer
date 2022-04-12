using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrinkServer.Models;
using DrinkServer.Views.ViewModel;
using Microsoft.AspNetCore.Http;
using DrinkServer.Utilities;
using Newtonsoft.Json;
using DrinkServer.Helpers;
using DrinkServer.Data;
using Microsoft.AspNetCore.Authorization;
using DrinkServer.Filters;
using DrinkServer.Services;

namespace yavis_order.Controllers
{
    [Authorize(Roles ="Orders")]
    public class OrdersController : Controller
    {
        private readonly Yavis_OrderDbContext _context;
        private readonly DrinkContext _contextCart;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly int _teamId;
        private readonly int _userId;
        private readonly INLogService _nLogService;
        public OrdersController(Yavis_OrderDbContext context, DrinkContext contextCart, IHttpContextAccessor httpContextAccessor,INLogService nLogService)
        {
            _context = context;
            _contextCart = contextCart;
            _httpContextAccessor = httpContextAccessor;
            _nLogService = nLogService;

            _teamId = _httpContextAccessor.HttpContext.Session.GetObject<DrinkServer.ViewModels.LoginAuthorizeVM>("User").TeamId;
            _userId = _httpContextAccessor.HttpContext.Session.GetObject<DrinkServer.ViewModels.LoginAuthorizeVM>("User").UserId;
        }
        private User getLoginUser()
        {
            User user = _contextCart.Users.Where(row => row.Id == _userId).FirstOrDefault();
            return user;
        }

        [Authorize(Roles = "Orders_Place")]
        public IActionResult From_To()
        {
            List<OrdersPlaceMapping> ordersPlaceMappings;
            if (_teamId == 1)
            {
                ordersPlaceMappings = _context.OrdersPlaceMappings.ToList();
            }
            else
            {
                List<int> orderPlaceInclude = this.getOrderPlaceIncludeList();
                ordersPlaceMappings = _context.OrdersPlaceMappings.Where(row => orderPlaceInclude.Contains(row.Id)).ToList();
            }
            List<Warehouse> warehouses = _context.Warehouses.ToList();
            List<Store> stores = _context.Stores.ToList();

            List<FromToViewModel> model = new List<FromToViewModel>();

            foreach (var item in ordersPlaceMappings)
            {
                //toid => toName
                string toName = warehouses.Where(w => w.Id == item.OrderToId).SingleOrDefault().Name;

                //formId => fromName
                string fromName = "";

                if (item.OrderFromTable == "Warehouse")
                {
                    fromName = warehouses.Where(w => w.Id == item.OrderFromId).SingleOrDefault().Name;

                }
                else
                {

                    fromName = stores.Where(s => s.Id == item.OrderFromId).SingleOrDefault().Name;
                }

                model.Add(new FromToViewModel()
                {
                    OrderPlaceMappingId = item.Id,
                    FromName = fromName,
                    ToName = toName
                });
            }

            return View(model);
        }

        [Authorize(Roles = "Orders_Place")]
        public IActionResult Select_From_To(string FromToInfo)
        {
            HttpContext.Session.SetString("FromToInfo", FromToInfo);
            return RedirectToAction("Create_Edit");
        }
        [Authorize(Roles = "Orders_Place")]
        public IActionResult Create_Edit()
        {
            string formToInfo = HttpContext.Session.GetString("FromToInfo");//"20,Chino Spectrum Marketplace,fabot warehouse"

            List<Material> materials = _context.Materials.Include(m => m.MaterialCategory).ToList();

            List<Order_CreateEdit_ViewModel> model = new List<Order_CreateEdit_ViewModel>();

            foreach (var material in materials)
            {
                model.Add(new Order_CreateEdit_ViewModel()
                {
                    Id = material.Id,
                    ChineseName = material.ChineseName,
                    EnglishName = material.EnglishName,
                    Picture = material.Picture,
                    Sku = material.Sku,
                    Category = material.MaterialCategory.Name
                });


            }

            ViewBag.formToInfo = formToInfo;
            ViewBag.Categories = _context.MaterialCategories.ToList();

            return View(model);
        }
        [Authorize(Roles = "Orders_Place")]
        [HttpPost]
        public IActionResult Create_Edit(string QTYInfo, string formToInfo, string SelectCategies)
        {
            //"19@2,22@2"
            TempData["QTYInfo"] = QTYInfo;
            TempData["formToInfo"] = formToInfo; //"20,Chino Spectrum Marketplace,fabot warehouse"
            TempData["SelectCategies"] = SelectCategies;

            return RedirectToAction("Review");
        }
        [Authorize(Roles = "Orders_Place")]
        public IActionResult Review()
        {
            string QTYInfo = TempData["QTYInfo"].ToString();
            string formToInfo = TempData["formToInfo"].ToString(); //"20,Chino Spectrum Marketplace,fabot warehouse"
            string SelectCategies = TempData["SelectCategies"].ToString();
            List<MaterialCategory> MaterialCategories = _context.MaterialCategories.Include(c => c.Materials).ToList();
            ViewBag.formToInfo = formToInfo; //"20,Chino Spectrum Marketplace,fabot warehouse"
            ViewBag.QTYInfos = QTYInfo.Split(',').ToDictionary(qty => qty.Split('@')[0], qty => qty.Split('@')[1]);
            ViewBag.SelectCategies = SelectCategies.Split(',').ToList();


            return View(MaterialCategories);
        }
        [Authorize(Roles = "Orders_Place")]
        [HttpPost]
        public IActionResult Review(string QTYInfo, string formToInfo, string SelectCategies)
        {
            
            int ordersPlaceMappingId = int.Parse(formToInfo.Split(',')[0]);
            //Save Order
            Order order = new Order() { Status = "1", OrdersPlaceMappingId = ordersPlaceMappingId, UserId = _userId, DeliveryDate = DateTime.Now };
            _context.Orders.Add(order);
            _context.SaveChanges();

            //"19@2,21@3"
            var qtyInfos = QTYInfo.Split(',').ToDictionary(qty => qty.Split('@')[0], qty => qty.Split('@')[1]);

            foreach (var item in qtyInfos)
            {
                OrderDetail od = new OrderDetail()
                {
                    OrderId = order.Id,
                    MaterialId = int.Parse(item.Key),
                    Count = int.Parse(item.Value)
                };
                _context.OrderDetails.Add(od);

            }
            _context.SaveChanges();

            Order orderInfo = _context.Orders.
                Include(o => o.OrderDetails).
                ThenInclude(od => od.Material).
                SingleOrDefault(o => o.Id == order.Id);

            var logObjects = orderInfo.OrderDetails.
                Select(od => new { od.Material.Sku, od.Material.EnglishName, od.Material.ChineseName, od.Count }).
                ToList();
            _nLogService.NlogStart("Orders Create");
            _nLogService.NlogObject(logObjects);
            _nLogService.NlogEnd("Orders Create");
            ////LOG
            //Log log = new Log()
            //{
            //    Fielid = "Order",
            //    Old = "Add",
            //    New = JsonConvert.SerializeObject(logObjects)
            //};
            //_context.Logs.Add(log);
            //_context.SaveChanges();




            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Orders_Proccess")]
        public async Task<IActionResult> Process(int id)
        {

            Order order = await _context.Orders.
                Include(o => o.OrderDetails).
                ThenInclude(od => od.Material).
                ThenInclude(m => m.MaterialCategory).
                Include(o => o.OrdersPlaceMapping).
                FirstOrDefaultAsync(p => p.Id == id);

            var orderDetailGroup = order.OrderDetails.GroupBy(od => od.Material.MaterialCategory.Name).ToList();


            Dictionary<int, string> storeMappings = _context.Stores.ToDictionary(s => s.Id, s => s.Name);
            Dictionary<int, string> warehouseMappings = _context.Warehouses.ToDictionary(w => w.Id, w => w.Name);
            ViewBag.ToName = warehouseMappings[order.OrdersPlaceMapping.OrderToId];
            ViewBag.FromName =
           order.OrdersPlaceMapping.OrderFromTable.ToUpper() == "WAREHOUSE" ? warehouseMappings[order.OrdersPlaceMapping.OrderFromId] : storeMappings[order.OrdersPlaceMapping.OrderFromId];
            ViewBag.OrderId = id;

            return View(orderDetailGroup);
        }
        //public async Task<IActionResult> Process2(int id)
        //{
        //    string QTYInfo = string.Empty; //TempData["QTYInfo"].ToString();
        //    string formToInfo = string.Empty; //TempData["formToInfo"].ToString(); ;//"20,Chino Spectrum Marketplace,fabot warehouse"
        //    string SelectCategies = string.Empty; //TempData["SelectCategies"].ToString();

        //    Order order = await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
        //    List<string> QTYInfoList = new List<string>();
        //    List<string> SelectCategiesList = new List<string>();

        //    foreach (var item in _context.OrderDetails.Where(p => p.OrderId == id))
        //    {
        //        QTYInfoList.Add($"{item.MaterialId}@{item.Count}");
        //        Material material = _context.Materials.FirstOrDefault(p => p.Id == int.Parse(item.MaterialId.ToString()));
        //        string name = _context.MaterialCategories.Where(p => p.Id == material.MaterialCategoryId).First().Name;
        //        if (!SelectCategiesList.Contains(name))
        //            SelectCategiesList.Add(name);
        //    }
        //    QTYInfo = string.Join(",", QTYInfoList);
        //    SelectCategies = string.Join(",", SelectCategiesList);


        //    OrdersPlaceMapping ordersPlaceMapping
        //    = await _context.OrdersPlaceMappings.FirstOrDefaultAsync(p => p.Id == order.OrdersPlaceMappingId);
        //    var warehourse = _context.Warehouses.Where(p => p.Id == ordersPlaceMapping.OrderToId).FirstOrDefault();
        //    string fromName = string.Empty;
        //    if (ordersPlaceMapping.OrderFromTable.ToUpper() == "WAREHOUSE")
        //    {
        //        fromName = _context.Warehouses.Where(p => p.Id == ordersPlaceMapping.OrderFromId).FirstOrDefault().Name;
        //    }
        //    else
        //    {
        //        fromName = _context.Stores.Where(p => p.Id == ordersPlaceMapping.OrderFromId).FirstOrDefault().Name;
        //    }
        //    formToInfo = $"{ordersPlaceMapping.Id},{fromName},{warehourse.Name}";
        //    List<MaterialCategory> MaterialCategories = _context.MaterialCategories.Include(c => c.Materials).ToList();
        //    ViewBag.formToInfo = formToInfo; //"20,Chino Spectrum Marketplace,fabot warehouse"

        //    // ViewBag.QTYInfos = QTYInfo.Split(',').ToDictionary(qty => qty.Split('@')[0], qty => qty.Split('@')[1]);
        //    Dictionary<string, string> dic = new Dictionary<string, string>();
        //    foreach (var item in QTYInfo.Split(','))
        //    {
        //        var array = item.Split('@');
        //        if (dic.Keys.Contains(array[0]))
        //        {
        //            dic[array[0]] = dic[array[0]] + $",{array[0]}";
        //        }
        //        else
        //        {
        //            dic.Add(array[0], array[1]);
        //        }
        //    }
        //    ViewBag.QTYInfos = dic;//QTYInfo.Split(',').ToDictionary(qty => qty.Split('@')[0], qty => qty.Split('@')[1]);
        //    ViewBag.SelectCategies = SelectCategies.Split(',').ToList();
        //    ViewBag.ForSaveQTYInfos = QTYInfo;
        //    ViewBag.OrderId = id;

        //    return View(MaterialCategories);
        //}
        [Authorize(Roles = "Orders_Proccess")]
        [HttpPost]
        public IActionResult Process(int orderId, string Staus, string DeliveryDate, string Notes)
        {

            //Save Order
            Order order = _context.Orders.FirstOrDefault(p => p.Id == orderId);
            order.DeliveryDate = DateTime.Parse(DeliveryDate);
            order.Status = Staus;
            order.Notes = Notes;
            _context.Orders.Update(order);

            _context.SaveChanges();


            Order orderInfo = _context.Orders.
             Include(o => o.OrderDetails).
             ThenInclude(od => od.Material).
             SingleOrDefault(o => o.Id == order.Id);

            var logObjects = orderInfo.OrderDetails.
                Select(od => new { od.Material.Sku, od.Material.EnglishName, od.Material.ChineseName, od.Count }).
                ToList();

            _nLogService.NlogStart("Orders Process");
            _nLogService.NlogObject(logObjects);
            _nLogService.NlogEnd("Orders Process");



            ////LOG
            //Log log = new Log()
            //{
            //    Fielid = "Order",
            //    Old = "Add",
            //    New = JsonConvert.SerializeObject(logObjects)
            //};
            //_context.Logs.Add(log);
            //_context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = orderId });
        }

        
        public IActionResult Index(string status = "0", int page = 1)
        {
            int page_count = 3;
            ViewBag.StoreMappings = _context.Stores.ToDictionary(s => s.Id, s => s.Name);
            ViewBag.WarehouseMappings = _context.Warehouses.ToDictionary(w => w.Id, w => w.Name);

            List<Order> orders;
            if (_teamId == 1)
            {
                orders = _context.Orders.Include(o => o.OrdersPlaceMapping).OrderBy(o => o.Id).ToList();
            }
            else
            {
                List<int> OrdersPlaceMappingIdList = getOrderPlaceMappingIdList();
                orders = _context.Orders.Include(o => o.OrdersPlaceMapping).Where(row => OrdersPlaceMappingIdList.Contains((int)row.OrdersPlaceMappingId)).OrderBy(o => o.Id).ToList();
            }

            if (!(status == "0" || string.IsNullOrEmpty(status)))
            {
                orders = orders.Where(o => o.Status == status).OrderBy(o => o.Id).ToList();
            }
            //else
            //{
            //    orders = _context.Orders.Include(o => o.OrdersPlaceMapping).Where(o => o.Status == status).OrderBy(o => o.Id).ToList();
            //}
            int pages = orders.GetPages(page_count);
            IEnumerable<Order> model = orders.GetPages(page_count, page);
            ViewData["pages"] = pages;
            ViewData["nowpage"] = page;
            ViewData["status"] = status;
            return View(model.ToList());
        }

        public IActionResult IndexTest(int page = 1)
        {
            int page_count = 5;
            ViewBag.StoreMappings = _context.Stores.ToDictionary(s => s.Id, s => s.Name);
            ViewBag.WarehouseMappings = _context.Warehouses.ToDictionary(w => w.Id, w => w.Name);

            var orders = _context.Orders.Include(o => o.OrdersPlaceMapping).ToList();
            int pages = orders.GetPages(page_count);
            IEnumerable<Order> model = orders.GetPages(page_count, page);
            ViewData["pages"] = pages;
            ViewData["nowpage"] = page;
            return View(model.ToList());

        }

        public IActionResult Details(int Id)
        {
            Order order = _context.Orders.Where(o => o.Id == Id).
                Include(o => o.OrdersPlaceMapping).
                Include(o => o.OrderDetails).
                ThenInclude(od => od.Material).
                ThenInclude(odm => odm.MaterialCategory).
                SingleOrDefault();

            ViewBag.ToMappings = _context.Warehouses.Where(w => w.Id == order.OrdersPlaceMapping.OrderToId).SingleOrDefault().Name;
            if (order.OrdersPlaceMapping.OrderFromTable == "Store")
            {
                ViewBag.FromMappings = _context.Stores.Where(s => s.Id == order.OrdersPlaceMapping.OrderFromId).SingleOrDefault().Name;
            }
            else
            {
                ViewBag.FromMappings = _context.Warehouses.Where(w => w.Id == order.OrdersPlaceMapping.OrderFromId).SingleOrDefault().Name;
            }

            ViewBag.SelectCategies = order.OrderDetails.Select(od => od.Material.MaterialCategory.Name).Distinct().ToList();

            var message = _context.Messages.Where(m => m.OtherId == Id).ToList();
            List<MessagesVM> messagesVMs = new List<MessagesVM>();
            foreach (var item in message)
            {
                MessagesVM row = new MessagesVM();
                row.Id = item.Id;
                row.Contents = item.Contents;
                row.DateTime = item.DateTime.Value;
                row.MappingTable = item.MappingTable;
                row.OtherId = item.OtherId.Value;
                row.UserId = item.UserId.Value;
                string displayName = _contextCart.Users.Where(row => row.Id == item.UserId.Value).FirstOrDefault().DisplayName;
                row.DisplayName = displayName;
                messagesVMs.Add(row);
            }

            ViewBag.Messages = messagesVMs;
            var user = getLoginUser();
            ViewBag.LoginDisplayname = user.DisplayName;
            return View(order);
        }

        public IActionResult Details_Edit(int Id)
        {
            Order order = _context.Orders.Where(o => o.Id == Id).
               Include(o => o.OrdersPlaceMapping).
               Include(o => o.OrderDetails).
               ThenInclude(od => od.Material).
               ThenInclude(odm => odm.MaterialCategory).
               SingleOrDefault();

            ViewBag.ToMappings = _context.Warehouses.Where(w => w.Id == order.OrdersPlaceMapping.OrderToId).SingleOrDefault().Name;
            if (order.OrdersPlaceMapping.OrderFromTable == "Store")
            {
                ViewBag.FromMappings = _context.Stores.Where(s => s.Id == order.OrdersPlaceMapping.OrderFromId).SingleOrDefault().Name;
            }
            else
            {
                ViewBag.FromMappings = _context.Warehouses.Where(w => w.Id == order.OrdersPlaceMapping.OrderFromId).SingleOrDefault().Name;
            }


            ViewBag.Categories = _context.MaterialCategories.ToList();

            return View(order);
        }

        [HttpPost]
        public IActionResult Details_Edit(int OrderId, string QTYInfo)
        {
            //tuple
            //"19@2,22@2"
            //List<(int id , int count)> qtyList =  
            //    QTYInfo.
            //    Split(',').
            //    Select(str => (int.Parse(str.Split('@')[0]) , int.Parse(str.Split('@')[1]))).ToList();

            Dictionary<int, int> qtyDictionary =
                QTYInfo.
                Split(',').
                ToDictionary(str => int.Parse(str.Split('@')[0]), str => int.Parse(str.Split('@')[1]));

            List<OrderDetail> orderDetails = _context.OrderDetails.Where(od => od.Order.Id == OrderId).ToList();

            foreach (var item in orderDetails)
            {
                item.Count = qtyDictionary[item.Id];
            }


            Order order = _context.Orders.FirstOrDefault();

            _context.SaveChanges();
            Order orderInfo = _context.Orders.
             Include(o => o.OrderDetails).
             ThenInclude(od => od.Material).
             SingleOrDefault(o => o.Id == order.Id);

            var logObjects = orderInfo.OrderDetails.
                Select(od => new { od.Material.Sku, od.Material.EnglishName, od.Material.ChineseName, od.Count }).
                ToList();

            _nLogService.NlogStart("Orders Update");
            _nLogService.NlogObject(logObjects);
            _nLogService.NlogEnd("Orders Update");


            ////LOG
            //Log log = new Log()
            //{
            //    Fielid = "Order",
            //    Old = "Add",
            //    New = JsonConvert.SerializeObject(logObjects)
            //};
            //_context.Logs.Add(log);
            //_context.SaveChanges();

            //_context.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = OrderId });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var orders = await _context.Orders.FindAsync(id);
            var orders = await _context.Orders
                .Include(m => m.OrderDetails)
                .FirstOrDefaultAsync(m => m.Id == id);
            foreach (var od in orders.OrderDetails)
            {
                _context.OrderDetails.Remove(od);
            }
            Order order = _context.Orders.AsNoTracking().FirstOrDefault(p=>p.Id==id);

            Order orderInfo = _context.Orders.
             Include(o => o.OrderDetails).
             ThenInclude(od => od.Material).
             SingleOrDefault(o => o.Id == order.Id);

            var logObjects = orderInfo.OrderDetails.
                Select(od => new { od.Material.Sku, od.Material.EnglishName, od.Material.ChineseName, od.Count }).
                ToList();

            _nLogService.NlogStart("Order Update");
            _nLogService.NlogObject(logObjects);
            _nLogService.NlogEnd("Order Update");

            _context.Orders.Remove(orders);



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Log_Details()
        {

            return View(_context.Logs.ToList());
        }


        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult testError()
        {
            throw new Exception("系統出錯請通知資訊人員");
        }
        private List<int> getOrderPlaceMappingIdList()
        {
            if (_teamId == 1)
                return _context.OrdersPlaceMappings.Select(row => row.Id).ToList();

            //Team所新增的訂單
            List<int> orderPlaceInclude = this.getOrderPlaceIncludeList();

            //Team倉庫權限可以處理的訂單
            List<int> wareHouseId = _contextCart.Teams_ProcessOrders.Where(p => p.TeamId == _teamId).Select(row => row.WarehouseId).ToList();
            List<int> orderProcessInclude = _context.OrdersPlaceMappings.Where(row => wareHouseId.Contains(row.OrderToId)).Select(row => row.Id).ToList();

            List<int> OrdersPlaceMappingIdList = orderPlaceInclude.Union(orderProcessInclude).ToList();

            return OrdersPlaceMappingIdList;
        }

        private List<int> getOrderPlaceIncludeList()
        {
            if (_teamId == 1)
                return _contextCart.Teams_PlaceOrders.Select(row => row.OrdersPlaceMappingId).ToList();

            return _contextCart.Teams_PlaceOrders.Where(p => p.TeamId == _teamId).Select(row => row.OrdersPlaceMappingId).ToList();
        }
        [HttpPost]
        public async Task<IActionResult> OrderMessage(Messages message)
        {
            message.DateTime = DateTime.Now;
            message.UserId = _userId;

            _context.Messages.Add(message);

            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = message.OtherId });

        }
    }
}
