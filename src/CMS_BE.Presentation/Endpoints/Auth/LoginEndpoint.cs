using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Auth.Commands.Login;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CMS_BE.Presentation.Endpoints.Auth
{
    public class LoginEndpoint(ISender sender)
        : EndpointBaseAsync.WithRequest<LoginCommand>.WithActionResult<ApiResponse<LoginResponse>>
    {
        [HttpPost(Router.AuthRoute.Login)]
        [SwaggerOperation(Tags = [Router.AuthRoute.AuthTags], Summary = "Logging in Account")]
        public override async Task<ActionResult<ApiResponse<LoginResponse>>> HandleAsync(
            [FromBody] LoginCommand request,
            CancellationToken cancellationToken = default
        ) => (await sender.Send(request, cancellationToken)).ToActionResult();
    }
}
