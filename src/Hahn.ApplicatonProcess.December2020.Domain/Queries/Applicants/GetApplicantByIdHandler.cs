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
    /// <seealso cref="MediatR.IRequestHandler{GetApplicantByIdQuery, (bool found, string message, GetApplicantResponse response)}" />
    public class GetApplicantByIdHandler : IRequestHandler<GetApplicantByIdQuery, (bool found, string message, GetApplicantResponse response)>
    {
        private readonly IApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetApplicantByIdHandler"/> class.
        /// </summary>
        /// <param name="applicationDbContext">The application database context.</param>
        /// <param name="mapper">The mapper.</param>
        public GetApplicantByIdHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }
        /// <summary>
        /// Handles a request for getting applicant by id
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<(bool found, string message, GetApplicantResponse response)> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            GetApplicantResponse query = await applicationDbContext.Applicants
                .ProjectTo<GetApplicantResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (query == null) return (false, "The applicant can not be fount with the given id", null);
            return (true, "The applicant is  found", query);
        }
    }
}
