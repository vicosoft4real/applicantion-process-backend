using Hahn.ApplicatonProcess.December2020.Data.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Delete
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Delete.DeleteApplicantCommand, (System.Boolean succeed, System.String message)}" />
    public class DeleteApplicantHandler : IRequestHandler<DeleteApplicantCommand, (bool succeed, string message)>
    {
        private readonly IApplicationDbContext applicationDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteApplicantHandler"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        public DeleteApplicantHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool succeed, string message)> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await applicationDbContext.Applicants.FindAsync(request.Id);
            if (applicant == null) return (false, "The applicant can not be found");
            applicationDbContext.Applicants.Remove(applicant);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return (true, "Applicant has been deleted successfully");
        }
    }
}
