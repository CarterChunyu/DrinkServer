using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrinkServer.Views.ViewModel
{
    public class WarehouseCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Code.")]
        [Remote(action: "isCodeNull",controller: "WarehouseCreateViewModels")]
        public long? Code { get; set; }
        [Required(ErrorMessage = "Please enter a Warehouse Name.")]
        public string Name { get; set; }
        public string Note { get; set; }
        public bool Status { get; set; }
        public int LocationId { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Location Location { get; set; }

        public int OrderId { get; set; }
        //public List<string> OrderToTable { get; set; }
        public int? OrderToId { get; set; }
        //public List<string> OrderFromTable { get; set; }
        public int? OrderFromId { get; set; }
    }
}
