using DrinkServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.ViewModels
{
    public class TeamVM
    {
        public List<StoreCheckVM> StoreVMs { get; set; }
        public List<Warehouse_SupportCheckVM> Warehouse_SupportVM { get; set; }
        public List<WarehouseCheckVM> WarehouseVMs { get; set; }
        public List<UserCheckVM> UserVMs { get; set; }
    }
    public class TeamEditVM : TeamVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Team Name.")]
        public string Name { get; set; }
    }
    public class TeamCreateVM : TeamVM
    {
        [Required(ErrorMessage = "Please enter a Team Name.")]
        [Remote(action: "IsNameExisted", controller: "Team")]
        public string Name { get; set; }       
    }

    public class StoreCheckVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Flag { get; set; }
    }
    public class Warehouse_SupportCheckVM
    {
        public int Id { get; set; }
        public string FromType { get; set; }
        public int FromId { get; set; }
        public string FromName { get; set; }
        public string ToType { get; set; }
        public int ToId { get; set; }
        public string ToName { get; set; }
        public bool Flag { get; set; }
    }
    public class WarehouseCheckVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Flag { get; set; }
        public string Type { get; set; }
    }
    public class UserCheckVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Flag { get; set; }
    }

    public class TeamIndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class ManageMeberVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserCheckVM> UserVMs { get; set; }
    }
    public class TeamAdminVM
    {
        public TeamAdminVM()
        {
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
