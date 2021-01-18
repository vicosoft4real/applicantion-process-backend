using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Interface;
using Hahn.ApplicatonProcess.December2020.Data.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Create
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateApplicantHandler : IRequestHandler<CreateApplicantCommand, (bool succeed, string message, int id)>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationDbContext"></param>
        /// <param name="mapper"></param>
        public CreateApplicantHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<(bool succeed, string message, int id)> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            Applicant applicant = mapper.Map<Applicant>(request);

            await applicationDbContext.Applicants.AddAsync(applicant, cancellationToken);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return (true, "The applicant has been created successfully", applicant.Id);
        }
    }
}
