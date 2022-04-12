using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Store
    {
        public Store()
        {
            Team_Report_Stores = new HashSet<Teams_Report_Store>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Store Name.")]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "Please enter Code.")]
        public long? Code { get; set; }
        public string Note { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual ICollection<Teams_Report_Store> Team_Report_Stores { get; set; }

        [ForeignKey(nameof(LocationId))]
        [InverseProperty("Stores")]
        public virtual Location Location { get; set; }
    }
}
