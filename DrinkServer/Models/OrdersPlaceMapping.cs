using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class OrdersPlaceMapping
    {
        public OrdersPlaceMapping()
        {
            Teams_PlaceOrders = new HashSet<Teams_PlaceOrder>();
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string OrderFromTable { get; set; }
        public int OrderFromId { get; set; }
        public int OrderToId { get; set; }
        public string OrderToTable { get; set; }
        public virtual ICollection<Teams_PlaceOrder> Teams_PlaceOrders { get; set; }

        [InverseProperty(nameof(Order.OrdersPlaceMapping))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
