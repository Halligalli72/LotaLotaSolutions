using System;
using Lotachamp.Application.Interfaces;
using Lotachamp.Persistance;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lotachamp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();

            //Initialize the db
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = (AppDbContext)scope.ServiceProvider.GetService<ILotachampContext>();
                    AppDbContextInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    //TODO: Add logging
                    //var logsvc = scope.ServiceProvider.GetService<ILoggingService>();
                    //logsvc.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
