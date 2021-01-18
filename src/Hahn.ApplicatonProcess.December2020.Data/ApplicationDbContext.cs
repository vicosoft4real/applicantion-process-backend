using Hahn.ApplicatonProcess.December2020.Data.Configuration;
using Hahn.ApplicatonProcess.December2020.Data.Interface;
using Hahn.ApplicatonProcess.December2020.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    /// <summary>
    /// Application Ef Core Db Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="Hahn.ApplicatonProcess.December2020.Data.Interface.IApplicationDbContext" />
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {

        }
        /// <summary>
        /// Gets or sets the applicants.
        /// </summary>
        /// <value>
        /// The applicants.
        /// </value>
        public DbSet<Applicant> Applicants { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicantConfiguration).Assembly);
        }


        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellation">The cancellation.</param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellation)
        {
            return base.SaveChangesAsync(cancellation);
        }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
