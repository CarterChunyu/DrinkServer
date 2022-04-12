using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Views.ViewModel
{
    public class WhareHousesVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Code.")]
        public long Code { get; set; }
        [Required(ErrorMessage = "Please enter a Warehouse Name.")]
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
   
        public int OrderId { get; set; }
        public string OrderToTable { get; set; }
        public int? OrderToId { get; set; }
        public string OrderFromTable { get; set; }
        public int? OrderFromId { get; set; }
    }
}
