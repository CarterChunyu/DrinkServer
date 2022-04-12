using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;

namespace DrinkServer.Data
{
    public class DrinkContext:DbContext
    {
        public DrinkContext(DbContextOptions<DrinkContext> options):base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<MaterialMapping> MaterialMappings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Teams_Report_Store> Team_Report_Stores { get; set; }
        public DbSet<Teams_PlaceOrder> Teams_PlaceOrders { get; set; }
        public DbSet<Teams_ProcessOrder> Teams_ProcessOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<OrdersPlaceMapping> OrdersPlaceMappings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ToDo...... 初始資料
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,DisplayName="admin",Email="",LoginName="admin",             
                Password= "VFDPYJgb90UzmpanFw3lEhzzfNz9QzqCjustl2zucbE=",
                Status=true,TeamId=1               
            });
            modelBuilder.Entity<Team>().HasData(new Team()
            {
                Id = 1,
                Name = "adminteam",
                Status=true              
            });
        }
    }
}
