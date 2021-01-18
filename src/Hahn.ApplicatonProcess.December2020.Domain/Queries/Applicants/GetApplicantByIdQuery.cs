using Hahn.ApplicatonProcess.December2020.Data.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Interface;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{(System.Boolean found, System.String message, Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants.GetApplicantResponse)}" />
    public class GetApplicantByIdQuery : IRequest<(bool found, string message, GetApplicantResponse response)>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
    }
}
