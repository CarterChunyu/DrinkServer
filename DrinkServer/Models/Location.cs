using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Location
    {
        public Location()
        {
            Stores = new HashSet<Store>();
            Warehouses = new HashSet<Warehouse>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
