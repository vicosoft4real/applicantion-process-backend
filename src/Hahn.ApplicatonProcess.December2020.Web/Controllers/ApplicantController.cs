using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Create;
using Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Delete;
using Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Update;
using Hahn.ApplicatonProcess.December2020.Domain.Queries.Applicants;
using Hahn.ApplicatonProcess.December2020.Web.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Controller" />
    [ApiVersion("1.0")]
    public class ApplicantController : BaseApiController
    {
        private readonly LinkGenerator linkGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicantController"/> class.
        /// </summary>
        /// <param name="linkGenerator">The link generator.</param>
        public ApplicantController(LinkGenerator linkGenerator)
        {
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Registers the applicant asynchronous.
        /// </summary>
        /// <param name="createApplicantCommand">The create applicant command.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Response<CreateApplicantCommand>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response<IEnumerable<ValidationFailure>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterApplicantAsync([FromBody] CreateApplicantCommand createApplicantCommand)
        {
            (bool succeed, string message, int id) = await Mediator.Send(createApplicantCommand);
            if (succeed)
            {

                return Created(linkGenerator.GetPathByAction(HttpContext, null, null, new { id = id }), createApplicantCommand.ToResponse<CreateApplicantCommand>());
            }
            return BadRequest(message);
        }

        /// <summary>
        /// Updates the applicant asynchronous.
        /// </summary>
        /// <param name="updateApplicant">The update applicant.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(Response<UpdateApplicantCommand>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<ValidationFailure>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateApplicantAsync([FromBody] UpdateApplicantCommand updateApplicant)
        {
            (bool succeed, string message, UpdateApplicantCommand update) = await Mediator.Send(updateApplicant);
            if (succeed)
            {
                return Ok(update.ToResponse<UpdateApplicantCommand>(true, message));
            }
            return BadRequest(message.ToResponse<string>(false, message));
        }

        /// <summary>
        /// Deletes the applicant asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<ValidationFailure>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteApplicantAsync(int id)
        {
            (bool succeed, string message) = await Mediator.Send(new DeleteApplicantCommand { Id = id });
            if (succeed)
            {
                return Ok(message.ToResponse<string>(true, message));
            }
            return BadRequest(message.ToResponse<string>(false, message));
        }
        /// <summary>
        /// Gets the by identifier applicant asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<GetApplicantByIdQuery>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetByIdApplicantAsync(int id)
        {
            (bool found, string message, GetApplicantResponse response) = await Mediator.Send(new GetApplicantByIdQuery { Id = id });
            if (found)
            {
                return Ok(response.ToResponse<GetApplicantResponse>(true, message));
            }
            return BadRequest(message.ToResponse<string>(false, message));
        }

        /// <summary>
        /// Gets all applicant asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Response<GetApplicantByIdQuery>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllApplicantAsync()
        {
            (bool found, string message, GetApplicantResponse[] response) = await Mediator.Send(new GetAllApplicntQuery { });
            if (found)
            {
                return Ok(response.ToResponse<GetApplicantResponse[]>(true, message));
            }
            return BadRequest(message.ToResponse<string>(false, message));
        }
    }
}
