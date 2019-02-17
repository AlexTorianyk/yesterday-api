using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) =>
                {
                    var environment = webHostBuilderContext.HostingEnvironment;
                    var pathOfCommonSettingsFile = Path.Combine(environment.ContentRootPath, "..", "Common");

                    configurationBuilder
                        .AddJsonFile("appsettings.json", optional: true)
                        .AddJsonFile($"appsettings.{environment.EnvironmentName}.json")
                        .AddJsonFile(Path.Combine(pathOfCommonSettingsFile, "commonsettings.json"), optional: true);

                    configurationBuilder.AddEnvironmentVariables();
                })
                .UseStartup<Startup>();
    }
}
