using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class MaterialMapping
    {
        [Key]
        public int Id { get; set; }
        public int? Count { get; set; }
        public int? Price { get; set; }
        public int? WarehouseId { get; set; }
        public int? MaterialId { get; set; }

        [ForeignKey(nameof(MaterialId))]
        [InverseProperty("MaterialMappings")]
        public virtual Material Material { get; set; }
        public virtual Warehouse Warehouses { get; set; }
    }
}
