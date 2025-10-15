using CMS_BE.Application.ApiWrapper;
using Mediator;

namespace CMS_BE.Application.Features.Auth.Queries.GetMe
{
    public class GetMeQuery : IRequest<Result<GetMeResponse>>;
}
