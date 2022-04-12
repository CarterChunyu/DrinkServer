using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;

namespace DrinkServer.Views.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Notes { get; set; }
        public string PrivateNote { get; set; }
        public int? UserId { get; set; }
        public int? OrdersPlaceMappingId { get; set; }

        //public virtual OrdersPlaceMapping OrdersPlaceMapping { get; set; }
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        //ordermapping Id
        public int OrderId { get; set; }
        public string OrderToTable { get; set; }
        public int? OrderToId { get; set; }
        public string OrderFromTable { get; set; }
        public int? OrderFromId { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }
}
