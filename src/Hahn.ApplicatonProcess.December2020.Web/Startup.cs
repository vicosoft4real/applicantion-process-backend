using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Create;
using Hahn.ApplicatonProcess.December2020.Web.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
            });

            services.AddDomainDependency();
            services.AddPersistence();
            services.AddSwagger();
            services.AddApiVersion();
            services.AddSerilogLogger(Configuration);
            services.AddCors();


        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger logger, IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicatonProcess.December2020.Web v1"));
            }
            app.UseSerilogRequestLogging();
            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseCors(x =>
            {
                x.WithOrigins(configuration.GetValue<string>("AllowOrigin"));
                x.AllowAnyHeader();
                x.AllowAnyMethod();
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
