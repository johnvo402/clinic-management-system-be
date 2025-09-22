using CMS_BE.Application.ApiWrapper;
using Mediator;

namespace CMS_BE.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<Result<RefreshTokenResponse>>
    {
        public string? RefreshToken { get; set; }
    }
}
