using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Warehouse
    {
        public Warehouse()
        {
            Teams_ProcessOrders = new HashSet<Teams_ProcessOrder>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Warehouse Name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Code.")]
        public long Code { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }  
        public DateTime CreateTime { get; set; }
        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        [InverseProperty("Warehouses")]
        public virtual Location Location { get; set; }
        public virtual ICollection<Teams_ProcessOrder> Teams_ProcessOrders { get; set; }
    }
}
