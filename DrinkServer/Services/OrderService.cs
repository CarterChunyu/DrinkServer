using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DrinkServer.Data;
using DrinkServer.Helpers;
using DrinkServer.Models;
using DrinkServer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DrinkServer.Services
{
    public class OrderService
    {
        private readonly DrinkContext _context;
        private readonly IHttpContextAccessor _accessor;
        public OrderService(DrinkContext context,IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public int Getnumber(int id)
        {
            LoginAuthorizeVM loginAuthorizeVM = _accessor.HttpContext.Session.GetObject<LoginAuthorizeVM>("User");
            Order order= _context.Orders.OrderByDescending(p => p.Id)
                .FirstOrDefault(p => p.UserId == loginAuthorizeVM.UserId);
            if (order == null)
                return 0;
            IEnumerable<OrderDetail> ods = _context.OrderDetails.Where(p => p.OrderId == order.Id);
            foreach (var item in ods)
            {
                if (item.MaterialId == id)
                {
                    var x= item.Count.GetValueOrDefault();                
                    return x;
                }
            }
            return 0;
        }


        public async Task<bool> GETX(int orderId)
        {
            LoginAuthorizeVM loginAuthorizeVM = _accessor.HttpContext.Session.GetObject<LoginAuthorizeVM>("User");
            IEnumerable<Teams_PlaceOrder>  teams_PlaceOrders=  _context.Teams_PlaceOrders.Where(p => p.TeamId == loginAuthorizeVM.TeamId).AsEnumerable();
            int ordersPlaceMappingId=
            (await _context.Orders.FirstOrDefaultAsync(p => p.Id == orderId)).OrdersPlaceMappingId.GetValueOrDefault();
            foreach (var item in teams_PlaceOrders)
            {
                if (item.OrdersPlaceMappingId == ordersPlaceMappingId)
                    return true;
            }
            return false;
        
        }
    }
}
