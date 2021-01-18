using FluentValidation.TestHelper;
using Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Create;
using Hahn.ApplicatonProcess.December2020.Web;
using Xunit;

namespace Hahn.ApplicatonProcess.Test.Validation
{

    public class CreateApplicantValidationTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private CreateApplicantValidation validator;
        public CreateApplicantValidationTest(CustomWebApplicationFactory<Startup> factory)
        {

            validator = new CreateApplicantValidation(factory.Services);
        }

        [Fact]
        public void Should_have_error_when_name_is_Empty()
        {

            validator.ShouldHaveValidationErrorFor(x => x.Name, "");

        }

        /// <summary>
        /// Should have error when name length is less than 5.
        /// </summary>
        [Fact]
        public void Should_have_error_when__name_length_is_less_than_5()
        {

            validator.ShouldHaveValidationErrorFor(x => x.Name, "test");

        }

        [Fact]
        public void Should_have_error_when__Familyname_length_is_empty5()
        {

            validator.ShouldHaveValidationErrorFor(x => x.FamilyName, "");

        }
        [Fact]
        public void Should_have_error_when__Familyname_length_is_less_than_5()
        {

            validator.ShouldHaveValidationErrorFor(x => x.FamilyName, "test");

        }
        [Fact]
        public void Should_have_error_when__Address_length_is_less_than_10()
        {

            validator.ShouldHaveValidationErrorFor(x => x.Address, "Address");

        }

        [Fact]
        public void Should_have_error_when_countryName_is_not_valid()
        {

            validator.ShouldHaveValidationErrorForAsync(x => x.CountryOfOrigin, "Not");

        }

        [Fact]
        public void Should_have_error_when_email_is_not_valid()
        {

            validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, "email@.@.@test");

        }
        [Fact]
        public void Should_have_error_when_age_is_not_between_20_and_50()
        {

            validator.ShouldHaveValidationErrorFor(x => x.Age, 1);

        }

        [Fact]
        public void Should_have_error_when_hired_is_is_null()
        {

            validator.ShouldHaveValidationErrorFor(x => x.Hired, default(bool?));

        }

        /// <summary>
        /// Should not have error when hire has value.
        /// </summary>
        [Fact]
        public void Should_not_have_error_when_hire_has_value()
        {

            validator.ShouldNotHaveValidationErrorFor(x => x.Hired, true);

        }

        [Fact]
        public void Should_not_have_error_when_country_is_valid()
        {

            validator.ShouldNotHaveValidationErrorForAsync(x => x.CountryOfOrigin, "Nigeria");

        }
        [Fact]
        public void Should_not_have_error_when_age_is_valid()
        {

            validator.ShouldNotHaveValidationErrorForAsync(x => x.Age, 21);

        }
        [Fact]
        public void Should_not_have_error_name_is_valid()
        {

            validator.ShouldNotHaveValidationErrorFor(x => x.Name, "Victor");

        }

        [Fact]
        public void Should_not_have_error_familyName_is_valid()
        {

            validator.ShouldNotHaveValidationErrorFor(x => x.FamilyName, "Ogundowo");

        }
    }
}
