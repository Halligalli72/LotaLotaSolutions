using Lotachamp.Application.Interfaces;
using Lotachamp.Infrastructure.Contracts;
using Lotachamp.Infrastructure.Logging;
using Lotachamp.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NLog;
using System;
using System.IO;
using System.Reflection;

namespace Lotachamp.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerSupport(this IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Lotachamp API",
                    Description = "A simple example ASP.NET Core Web API"
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lotachamp.Api V1");
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddTransient<ILoggingService, NLogService>();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:LotachampDb"];
            services.AddDbContext<ILotachampContext, AppDbContext>(o => o.UseSqlServer(connectionString));
        }

    }
}
