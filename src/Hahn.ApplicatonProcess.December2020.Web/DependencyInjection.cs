
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Net;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
            {

                var filePath = Path.Combine(AppContext.BaseDirectory, "Hahn.ApplicatonProcess.December2020.Web.xml");
                x.IncludeXmlComments(filePath, true);
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Application Process", Version = "v1" });
                x.AddFluentValidationRules();

                x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

            });
        }
        /// <summary>
        /// Adds the API version.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void AddApiVersion(this IServiceCollection service)
        {
            service.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
        }
        /// <summary>
        /// Adds the serilog logger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="config">The configuration.</param>
        public static void AddSerilogLogger(this IServiceCollection services, IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config).Enrich.FromLogContext().CreateLogger();

            services.AddSingleton(Log.Logger);


        }

    }
}
