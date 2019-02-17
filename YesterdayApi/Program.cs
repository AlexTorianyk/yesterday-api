using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace YesterdayApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
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