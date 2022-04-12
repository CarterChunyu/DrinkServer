using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int? Count { get; set; }
        public int? Price { get; set; }
        public int? MaterialId { get; set; }
        public int? OrderId { get; set; }

        [ForeignKey(nameof(MaterialId))]
        [InverseProperty("OrderDetails")]
        public virtual Material Material { get; set; }
        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
    }
}
