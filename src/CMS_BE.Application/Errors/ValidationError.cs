using CMS_BE.Application.ApiWrapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.Errors
{
    public class ValidationError(List<ValidationFailure> invalidParams)
        : ErrorDetails(
            "The request parameters didn't validate.",
            [
                .. invalidParams
                    .GroupBy(x => x.PropertyName)
                    .Select(failureGroups => new InvalidParam
                    {
                        PropertyName = failureGroups.Key,
                        Reasons = failureGroups.Select(failure =>
                        {
                            if (failure.ErrorMessage is string messageResult)
                            {
                                return new ErrorReason
                                {
                                    Message = messageResult ?? "Invalid value",
                                };
                            }
                            return new ErrorReason { Message = failure.ErrorMessage };
                        }),
                    }),
            ],
            nameof(ValidationError),
            StatusCodes.Status400BadRequest
        );
}
