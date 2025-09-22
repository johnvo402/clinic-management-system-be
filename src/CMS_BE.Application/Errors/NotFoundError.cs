using CMS_BE.Application.ApiWrapper;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.Errors
{
    public class NotFoundError(string title, string message)
        : ErrorDetails(title, message, nameof(NotFoundError), StatusCodes.Status404NotFound);
}
