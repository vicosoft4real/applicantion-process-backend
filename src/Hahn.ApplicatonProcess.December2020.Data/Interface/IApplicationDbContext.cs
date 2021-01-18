using Hahn.ApplicatonProcess.December2020.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Interface
{
    /// <summary>
    /// DbContext  interface 
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Gets or sets the applicants.
        /// </summary>
        /// <value>
        /// The applicants.
        /// </value>
        DbSet<Applicant> Applicants { get; set; }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellation">The cancellation.</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellation);
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

    }
}
