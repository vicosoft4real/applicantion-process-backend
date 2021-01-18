using Hahn.ApplicatonProcess.December2020.Data.Model;
using Hahn.ApplicatonProcess.December2020.Domain.Interface;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants
{


    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequest{(System.Boolean found, System.String message, Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants.GetApplicantResponse response)}" />
    /// <seealso cref="Hahn.ApplicatonProcess.December2020.Domain.Interface.IMapFrom{Hahn.ApplicatonProcess.December2020.Data.Model.Applicant}" />
    public class GetAllApplicntQuery : IRequest<(bool found, string message, GetApplicantResponse[] response)>
    {
    }
}
