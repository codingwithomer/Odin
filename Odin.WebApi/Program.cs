using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace Odin.WebApi
{
    public class Program
    {
        public static IConfiguration Configuration
        {
            get
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                return new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory())
                                                 .AddJsonFile(path: "appsettings.json", optional: false)
                                                 .AddJsonFile(path: $"appsettings.{environment}.json", optional: true)
                                                 .AddEnvironmentVariables()
                                                 .Build();
            }
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(Configuration);
                    webBuilder.UseStartup<Startup>();
                });
    }
}
