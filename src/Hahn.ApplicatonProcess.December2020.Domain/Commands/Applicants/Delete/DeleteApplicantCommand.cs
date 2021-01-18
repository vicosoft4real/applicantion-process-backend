using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Delete
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{(System.Boolean succeed, System.String message)}" />
    public class DeleteApplicantCommand : IRequest<(bool succeed, string message)>
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
