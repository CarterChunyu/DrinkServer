using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer.Helpers
{
    public static class SessionExtensionHelper
    {
        public static void SetObject<T>(this ISession session,string key,T value) where T : class
        {
            string json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }
        public static T GetObject<T>(this ISession session,string key)where T:class
        {           
            string json = session.GetString(key);
            //Console.WriteLine("123456");
            //Console.WriteLine(key);
            //Console.WriteLine(json);
            T value = JsonConvert.DeserializeObject<T>(json);
            return value;
        }
    }
}
