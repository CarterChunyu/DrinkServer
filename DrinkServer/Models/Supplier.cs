using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Supplier
    {
        public Supplier()
        {
            MaterialManufacturerSuppliers = new HashSet<Material>();
            MaterialVendorSuppliers = new HashSet<Material>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Code.")]
        public long? Code { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter a Supplier Name.")]
        public string Name { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please select at least one supplier Type.")]
        public string Type { get; set; }
        public string Notes { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateTime { get; set; }

        [InverseProperty(nameof(Material.ManufacturerSupplier))]
        public virtual ICollection<Material> MaterialManufacturerSuppliers { get; set; }
        [InverseProperty(nameof(Material.VendorSupplier))]
        public virtual ICollection<Material> MaterialVendorSuppliers { get; set; }
    }
}
