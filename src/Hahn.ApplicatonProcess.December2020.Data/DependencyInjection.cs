using Hahn.ApplicatonProcess.December2020.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    /// <summary>
    /// Dependency injection registration
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the persistence.
        /// </summary>
        /// <param name="services">The services.</param>

        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            o.UseInMemoryDatabase(databaseName: "ApplicationDb"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }
    }
}
