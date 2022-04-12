using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Models
{
    public class Team
    {
        public Team()
        {
            Users = new HashSet<User>();
            Teams_Report_Stores = new HashSet<Teams_Report_Store>();
            Teams_ProcessOrders = new HashSet<Teams_ProcessOrder>();
            Teams_PlaceOrders = new HashSet<Teams_PlaceOrder>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Teams_Report_Store> Teams_Report_Stores { get; set; }
        public virtual ICollection<Teams_ProcessOrder> Teams_ProcessOrders { get; set; }
        public virtual ICollection<Teams_PlaceOrder> Teams_PlaceOrders { get; set; }
    }
}
