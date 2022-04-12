using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? TotalAmount { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Notes { get; set; }
        public string PrivateNote { get; set; }
        public int? UserId { get; set; }
        public int? OrdersPlaceMappingId { get; set; }

        [ForeignKey(nameof(OrdersPlaceMappingId))]
        [InverseProperty("Orders")]
        public virtual OrdersPlaceMapping OrdersPlaceMapping { get; set; }
        [InverseProperty(nameof(OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
