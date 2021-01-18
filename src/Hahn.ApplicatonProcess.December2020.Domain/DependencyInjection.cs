using AutoMapper;
using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Commands.Applicants.Create;
using Hahn.ApplicatonProcess.December2020.Domain.Common.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Reflection;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    /// <summary>
    /// Dependency registration for domain layer
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds the domain dependency.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddDomainDependency(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(typeof(CreateApplicantValidation).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidation<,>));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddHttpClient("HttpClient").AddPolicyHandler(x =>
            {
                return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(1, retry => TimeSpan.FromSeconds(Math.Pow(1, retry)));
            });
        }
    }
}
