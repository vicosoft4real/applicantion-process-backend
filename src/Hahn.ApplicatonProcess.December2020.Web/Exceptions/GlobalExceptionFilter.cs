using FluentValidation;
using FluentValidation.Results;
using Hahn.ApplicatonProcess.December2020.Web.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Net;

namespace Hahn.ApplicatonProcess.December2020.Web.Exceptions
{
    /// <summary>
    /// /
    /// </summary>
    public static class GlobalExceptionFilter
    {

        /// <summary>
        /// Configures the exception handler.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="logger">The logger.</param>
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, Serilog.ILogger logger)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";


                    IExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {


                        logger.Information($"Something went wrong: {contextFeature.Error?.Message}");


                        if (contextFeature?.Error?.GetType() == typeof(ValidationException))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            ValidationException error = (ValidationException)contextFeature.Error;
                            Response<IEnumerable<ValidationFailure>>? response = error?.Errors.ToResponse<IEnumerable<ValidationFailure>>(false, "Validation error");
                            string? result = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            });

                            logger.Information($"Validation Error: {response}");

                            await context.Response.WriteAsync(result);

                        }

                        else
                        {
                            logger.Error($"Something went wrong: {contextFeature?.Error}");
                            await context.Response.WriteAsync(JsonConvert.SerializeObject("Server Error".ToResponse<string>(false, "Something went wrong"), new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                            }));

                        }
                    }

                });
            });
        }

    }

}
