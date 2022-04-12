using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Material
    {
        public Material()
        {
            MaterialMappings = new HashSet<MaterialMapping>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please enter Sku.")]
        [Column("SKU")]
        [StringLength(50)]
        public string Sku { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        [StringLength(50)]
        public string Unit { get; set; }
        [Column("PODescription")]
        [StringLength(50)]
        public string Podescription { get; set; }
        [StringLength(50)]
        public string Picture { get; set; }
        public bool? Availability { get; set; }
        public int? MaterialCategoryId { get; set; }
        public int? VendorSupplierId { get; set; }
        public int? ManufacturerSupplierId { get; set; }
        [StringLength(10)]
        public string DateTime { get; set; }
        [StringLength(50)]
        //[Required(ErrorMessage = "Please enter EnglishName.")]
        public string EnglishName { get; set; }
        [StringLength(50)]
        public string ChineseName { get; set; }

        [ForeignKey(nameof(ManufacturerSupplierId))]
        [InverseProperty(nameof(Supplier.MaterialManufacturerSuppliers))]
        public virtual Supplier ManufacturerSupplier { get; set; }
        [ForeignKey(nameof(MaterialCategoryId))]
        [InverseProperty("Materials")]
        public virtual MaterialCategory MaterialCategory { get; set; }
        [ForeignKey(nameof(VendorSupplierId))]
        [InverseProperty(nameof(Supplier.MaterialVendorSuppliers))]
        public virtual Supplier VendorSupplier { get; set; }
        [InverseProperty(nameof(MaterialMapping.Material))]
        public virtual ICollection<MaterialMapping> MaterialMappings { get; set; }
        [InverseProperty(nameof(OrderDetail.Material))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
