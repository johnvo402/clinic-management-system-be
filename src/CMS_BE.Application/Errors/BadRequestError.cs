using CMS_BE.Application.ApiWrapper;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.Errors
{
    public class BadRequestError(string messageResult)
        : ErrorDetails(messageResult, nameof(BadRequestError), StatusCodes.Status400BadRequest);
}
