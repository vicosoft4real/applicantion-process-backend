using Hahn.ApplicatonProcess.Application.Test.Validation;
using Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Create;
using Hahn.ApplicatonProcess.December2020.Web;
using Hahn.ApplicatonProcess.Test;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Hahn.ApplicatonProcess.Application.Test.Contoller
{
    public class ApplicationControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> factory;

        public ApplicationControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Registers the new applicant with valid input return 201.
        /// </summary>
        [Fact]
        public async Task Register_new_applicant_With_valid_Input_return_201()
        {
            //arrange
            var client = factory.CreateDefaultClient();
            var applicant = new CreateApplicantCommand
            {
                Address = "77 Community Road",
                Age = 25,
                CountryOfOrigin = "Nigeria",
                EmailAddress = "vicosoft4real@gmai.com",
                FamilyName = "Ogundowo",
                Hired = true,
                Name = "Victor"
            };
            var content = IntegrationTestHelper.GetRequestContent(applicant);

            //act

            var response = await client.PostAsync("api/v1/applicant", content);

            //assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
