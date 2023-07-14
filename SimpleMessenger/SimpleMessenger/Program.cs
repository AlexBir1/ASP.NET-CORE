using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMessenger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string timeNow = DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");
            string pathWithDate = $"MessengerLog_{timeNow}.txt";

            Log.Logger = new LoggerConfiguration()

                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
                .WriteTo.File($"./Logs/{pathWithDate}")

                .CreateLogger();

            Log.Information("STARTED NEW LOGGING SESSION");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
