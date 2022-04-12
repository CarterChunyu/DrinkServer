using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dirPath = Directory.CreateDirectory
                (Path.Combine(Directory.GetCurrentDirectory(), "Logs")).FullName;
            NLog.GlobalDiagnosticsContext.Set("LogDirectory", dirPath);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(builder =>
                {
                    builder.ClearProviders();
                    builder.SetMinimumLevel(LogLevel.Error);
                })
                .UseNLog();
    }
}
