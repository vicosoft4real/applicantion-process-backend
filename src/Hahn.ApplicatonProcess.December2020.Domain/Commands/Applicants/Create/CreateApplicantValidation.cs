using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Create
{
    /// <summary>
    /// Validation for creating new applicant command
    /// </summary>
    /// <seealso cref="AbstractValidator{CreateApplicantCommand}" />
    public class CreateApplicantValidation : AbstractValidator<CreateApplicantCommand>
    {
        private readonly IServiceProvider serviceProvider;




        /// <summary>
        /// Initializes a new instance of the <see cref="CreateApplicantValidation"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public CreateApplicantValidation(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

            RuleFor(x => x.Name).NotEmpty().MinimumLength(5).WithMessage("The name must be at least 5 characters");

            RuleFor(x => x.FamilyName).NotEmpty().MinimumLength(5).WithMessage("The family name number at least 5 characters");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Please provide valid email address");

            RuleFor(x => x.Age).NotEmpty().InclusiveBetween(20, 60).WithMessage("Age must be between 20 to 60");

            RuleFor(x => x.Hired).NotNull().WithMessage("Hired is required");

            RuleFor(x => x.Address).MinimumLength(10).WithMessage("The address should be at least 10 character long");

            RuleFor(x => x.CountryOfOrigin).NotEmpty().MustAsync(IsKnownCountry)
                .When(x => x.CountryOfOrigin != null)
                .WithMessage("Country name is not valid");

        }

        /// <summary>
        /// Determines whether [is known country] [the specified country].
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        ///   <c>true</c> if [is known country] [the specified country]; otherwise, <c>false</c>.
        /// </returns>
        private async Task<bool> IsKnownCountry(string country, CancellationToken token)
        {
            //todo this can wrapped into adapter
            IHttpClientFactory httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

            if (string.IsNullOrWhiteSpace(country)) return false;
            HttpClient httpClient = httpClientFactory.CreateClient("HttpClient");
            string url = configuration.GetValue<string>("Countries:Url");
            HttpRequestMessage content = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = new Uri($"{url}/{country}?fullText=true") };
            content.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await httpClient.SendAsync(content, token);
            return response.IsSuccessStatusCode;
        }
    }
}
