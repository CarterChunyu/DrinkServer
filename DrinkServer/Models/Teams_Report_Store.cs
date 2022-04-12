using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Teams_Report_Store
    {
        public int Id { get; set; }

        public int TeamId { get; set; }
        public int StoreId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store Store { get; set; }
    }
}
