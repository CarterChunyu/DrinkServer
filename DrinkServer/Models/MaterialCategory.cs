using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class MaterialCategory
    {
        public MaterialCategory()
        {
            Materials = new HashSet<Material>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter a MaterlCategory Name.")]
        public string Name { get; set; }
        public DateTime? DateTime { get; set; }

        [InverseProperty(nameof(Material.MaterialCategory))]
        public virtual ICollection<Material> Materials { get; set; }
    }
}
