using CMS_BE.Application.ApiWrapper;
using Mediator;

namespace CMS_BE.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<Result<LoginResponse>>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
