using CMS_BE.Application.ApiWrapper;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.Errors
{
    public class NotFoundError(string message)
        : ErrorDetails(message, nameof(NotFoundError), StatusCodes.Status404NotFound);
}
