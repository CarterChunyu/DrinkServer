using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Teams_PlaceOrder
    {
        public Teams_PlaceOrder()
        {

        }
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int OrdersPlaceMappingId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        [ForeignKey("OrdersPlaceMappingId")]
        public virtual OrdersPlaceMapping OrdersPlaceMapping { get; set; }
    }
}
