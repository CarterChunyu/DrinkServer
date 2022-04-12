using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Teams_ProcessOrder
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int WarehouseId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
    }
}
