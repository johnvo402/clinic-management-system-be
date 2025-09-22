using CMS_BE.Application.ApiWrapper;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.Errors
{
    public class ForbiddenError(string title)
        : ErrorDetails(
            title,
            "You do not have enough permission to access this resource",
            nameof(ForbiddenError),
            StatusCodes.Status403Forbidden
        );
}
