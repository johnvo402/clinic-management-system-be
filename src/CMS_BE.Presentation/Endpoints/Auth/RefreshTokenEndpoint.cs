using Ardalis.ApiEndpoints;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Features.Auth.Commands.RefreshToken;
using CMS_BE.Presentation.Routers;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CMS_BE.Presentation.Endpoints.Auth
{
    public class RefreshTokenEndpoint(ISender sender)
        : EndpointBaseAsync.WithRequest<RefreshTokenCommand>.WithActionResult<
            ApiResponse<RefreshTokenResponse>
        >
    {
        [HttpPost(Router.AuthRoute.RefreshToken)]
        [SwaggerOperation(Tags = [Router.AuthRoute.AuthTags], Summary = "Logging in Account")]
        public override async Task<ActionResult<ApiResponse<RefreshTokenResponse>>> HandleAsync(
            RefreshTokenCommand request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await sender.Send(request, cancellationToken);
            return result.ToActionResult();
        }
    }
}
