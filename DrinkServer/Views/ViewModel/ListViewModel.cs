using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;

namespace DrinkServer.Views.ViewModel
{
    
    public class ListViewModel
    {
        public List<Store> StoreList { get; set; }
        public List<Warehouse> WarehouseList { get; set; }
        
    }
}
