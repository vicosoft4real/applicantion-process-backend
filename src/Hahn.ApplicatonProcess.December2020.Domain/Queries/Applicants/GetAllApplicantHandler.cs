using AutoMapper;
using AutoMapper.QueryableExtensions;
using Hahn.ApplicatonProcess.December2020.Data.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants.GetAllApplicntQuery, (System.Boolean found, System.String message, Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants.GetApplicantResponse response)}" />
    public class GetAllApplicantHandler : IRequestHandler<GetAllApplicntQuery, (bool found, string message, GetApplicantResponse[] response)>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllApplicantHandler"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetAllApplicantHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }
        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<(bool found, string message, GetApplicantResponse[] response)> Handle(GetAllApplicntQuery request, CancellationToken cancellationToken)
        {

            GetApplicantResponse[] query = await applicationDbContext.Applicants
                .ProjectTo<GetApplicantResponse>(mapper.ConfigurationProvider)
                .ToArrayAsync();
            if (query == null) return (false, "The applicant can not be fount with the given id", null);
            return (true, "The applicant is  found", query);
        }
    }
}
