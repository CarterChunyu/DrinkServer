using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DrinkServer.Views.ViewModel
{
    public class MaterialCreateViewModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please enter Sku.")]
        //[Remote(action: "VerifySku", controller: "Materials")]
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string Unit { get; set; }
        public string Podescription { get; set; }
        public IFormFile Picture { get; set; }
        public bool? Availability { get; set; }
        public int? MaterialCategoryId { get; set; }
        public int? VendorSupplierId { get; set; }
        public int? ManufacturerSupplierId { get; set; }
        public string DateTime { get; set; }
        //public int WarehousesId { get; set; }
        //[Required(ErrorMessage = "Please enter a EnglishName Name.")]
        public string EnglishName { get; set; }
        public string ChineseName { get; set; }
        public virtual Supplier ManufacturerSupplier { get; set; }
        public virtual MaterialCategory MaterialCategory { get; set; }
        public virtual Supplier VendorSupplier { get; set; }
        public virtual Warehouse Warehouse { get; set; }

    }
}
