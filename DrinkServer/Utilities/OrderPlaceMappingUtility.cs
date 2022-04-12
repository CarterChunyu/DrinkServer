using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkServer.Models;

namespace DrinkServer.Utilities
{
    public class OrderPlaceMappingUtility
    {

        //public static Dictionary<int , string> GetToMappings(List<int> toIdList)
        //{
        //    Yavis_OrderDbContext db = new Yavis_OrderDbContext();

        //    Dictionary<int, string> result = new Dictionary<int, string>();

        //    foreach (int toId in toIdList)
        //    {
        //        string toName = db.Warehouses.Where(w => w.Id == toId).SingleOrDefault().Name;

        //        result.Add(toId, toName);
        //    }

        //    return result;
        //}

        //public static Dictionary<int, string> GetFromMappings(List<string> idTableMappings) //"30,Stores"   "30,Warehouse"
        //{
        //    Yavis_OrderDbContext db = new Yavis_OrderDbContext();

        //    Dictionary<int, string> result = new Dictionary<int, string>();

        //    foreach (var mapping in idTableMappings) //key:id  value:tableName
        //    {
        //        int id = mapping.Key;
        //        string tableName = mapping.Value;

        //        string fromName="";
        //        if (tableName == "Store")
        //        {
        //            fromName = db.Stores.Where(w => w.Id == id).SingleOrDefault().Name;
        //        }
        //        else
        //        {
        //            fromName = db.Warehouses.Where(w => w.Id == id).SingleOrDefault().Name;
        //        }

        //        result.Add(id, fromName);
        //    }

        //    return result;
        //}

    }
}
