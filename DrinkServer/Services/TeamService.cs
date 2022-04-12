using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;
using DrinkServer.ViewModels;
using DrinkServer.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DrinkServer.Services
{
    public class TeamService : ITeamService
    {
        private readonly DrinkContext _context;
        public TeamService(DrinkContext context)
        {
            _context = context;
        }

        public async Task<T> GetTeamVM<T>
            (List<int> Report_StroeIds, List<int> Warehouse_SupportIds,
            List<int> Process_StoreIds, List<int> UserIds) where T : TeamVM, new()
        {
            List<Store> stores = await _context.Stores.ToListAsync();
            List<Warehouse> warehouses = await _context.Warehouses.ToListAsync();
            List<OrdersPlaceMapping> ordersPlaceMappings = await _context.
                OrdersPlaceMappings.ToListAsync();
            List<User> users = await _context.Users.ToListAsync();

            List<StoreCheckVM> storeVMs = new List<StoreCheckVM>();
            foreach (var item in stores)
            {
                StoreCheckVM storeVM = new StoreCheckVM()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Flag = Report_StroeIds.Contains(item.Id) == true ? true : false
                };
                storeVMs.Add(storeVM);
            }

            List<Warehouse_SupportCheckVM> warehouse_SupportVMs = new List<Warehouse_SupportCheckVM>();
            foreach (var item in ordersPlaceMappings)
            {
                string fromName = string.Empty;
                string fromType = string.Empty;
                if (item.OrderFromTable == "Store")
                {
                    fromName = stores.FirstOrDefault(p => p.Id == item.OrderFromId).Name;
                    fromType = "Store";
                }
                else
                {
                    fromName = warehouses.FirstOrDefault(p => p.Id == item.OrderFromId).Name;
                    fromType = "Warehouse";
                }
                string toName = warehouses.FirstOrDefault(p => p.Id == item.OrderToId).Name;
                string toType = "Warehouse";

                Warehouse_SupportCheckVM warehouse_SupportVM = new Warehouse_SupportCheckVM()
                {
                    Id = item.Id,
                    FromType = fromType,
                    FromId = item.OrderFromId,
                    FromName = fromName,
                    ToType = toType,
                    ToId = item.OrderToId,
                    ToName = toName,
                    Flag = Warehouse_SupportIds.Contains(item.Id) == true ? true : false
                };
                warehouse_SupportVMs.Add(warehouse_SupportVM);
            }

            List<WarehouseCheckVM> warehouseVMs = new List<WarehouseCheckVM>();
            foreach (var item in warehouses)
            {
                WarehouseCheckVM warehouseVM = new WarehouseCheckVM()
                {
                    Id = item.Id,
                    Type = "Warehouse",
                    Name = item.Name,
                    Flag = Process_StoreIds.Contains(item.Id) == true ? true : false
                };
                warehouseVMs.Add(warehouseVM);
            }

            List<UserCheckVM> userVMs = new List<UserCheckVM>();
            foreach (var item in users)
            {
                UserCheckVM userVM = new UserCheckVM()
                {
                    Id = item.Id,
                    Name = item.DisplayName,
                    Flag = UserIds.Contains(item.Id) == true ? true : false
                };
                userVMs.Add(userVM);
            }

            T t = new T()
            {
                StoreVMs = storeVMs,
                Warehouse_SupportVM = warehouse_SupportVMs,
                WarehouseVMs = warehouseVMs,
                UserVMs = userVMs
            };
            return t;
        }
    }
}
