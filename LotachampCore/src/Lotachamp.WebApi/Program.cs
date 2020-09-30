using System;
using Lotachamp.Application.Infrastructure;
using Lotachamp.Infrastructure.Persistance;
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
            var host = CreateWebHostBuilder(args).Build();

            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            //Initialize the db
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    logger.Debug("Initializing database...");
                    var context = (AppDbContext)scope.ServiceProvider.GetService<ILotachampContext>();
                    AppDbContextInitializer.Initialize(context);
                    logger.Debug("Database initialized.");
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "DATABASE INITIALIZE FAILED!");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
