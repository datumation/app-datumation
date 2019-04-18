using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace app_datumation
{
    public class Program
    {
          public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

        }



        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hosting.json", optional: true)
                .AddCommandLine(args)
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://*:44350")
                .UseConfiguration(config)
                .UseStartup<Startup>();
        }
    }
}
