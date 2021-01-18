using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Interface;
using Hahn.ApplicatonProcess.December2020.Data.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Update
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateApplicantHandler : IRequestHandler<UpdateApplicantCommand, (bool succeed, string message, UpdateApplicantCommand update)>
    {
        private readonly IApplicationDbContext applicationDbContext;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationDbContext"></param>

        public UpdateApplicantHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<(bool succeed, string message, UpdateApplicantCommand update)> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await applicationDbContext.Applicants.FindAsync(request.Id);
            if (applicant == null) return (false, "The applicant to be updated is not found", request);

            applicant.Address = request.Address;
            applicant.Age = request.Age;
            applicant.CountryOfOrigin = request.CountryOfOrigin;
            applicant.EmailAddress = request.EmailAddress;
            applicant.FamilyName = request.FamilyName;
            applicant.Hired = request.Hired;
            applicant.Name = request.Name;



            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return (true, "The applicant has been updated successfully", request);


        }
    }
}
