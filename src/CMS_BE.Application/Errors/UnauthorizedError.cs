using CMS_BE.Application.ApiWrapper;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.Errors
{
    public class UnauthorizedError(string title)
        : ErrorDetails(
            title,
            "You need to log in first to access this resource",
            nameof(UnauthorizedError),
            StatusCodes.Status401Unauthorized
        );
}
