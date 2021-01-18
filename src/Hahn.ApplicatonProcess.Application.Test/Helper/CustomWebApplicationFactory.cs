using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Hahn.ApplicatonProcess.December2020.Domain;
using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Web;
using Microsoft.Extensions.Configuration;

namespace Hahn.ApplicatonProcess.Test
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
           {

               services.AddDomainDependency();
               services.AddPersistence();
               services.AddApiVersion();

               var sp = services.BuildServiceProvider();
               var config = sp.GetRequiredService<IConfiguration>();
               services.AddSerilogLogger(config);


           }).UseEnvironment("Development");
        }

    }
}
