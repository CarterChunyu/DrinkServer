using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Views.ViewModel
{
    public class Order_CreateEdit_ViewModel
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public string Picture { get; set; } = string.Empty;
        public string Category { get; set; }
        public int QTY { get; set; }
    }
}
