using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Interfaces.Services;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Errors;
using CMS_BE.Domain.Aggregates.Auth;
using Mediator;

namespace CMS_BE.Application.Features.Auth.Queries.GetMe
{
    public class GetMeHandler(IUnitOfWork unitOfWork, ICurrentAccount currentAccount)
        : IRequestHandler<GetMeQuery, Result<GetMeResponse>>
    {
        public async ValueTask<Result<GetMeResponse>> Handle(
            GetMeQuery request,
            CancellationToken cancellationToken
        )
        {
            var currentId = currentAccount.Id;
            if (currentId == null)
            {
                return Result<GetMeResponse>.Failure(new UnauthorizedError("Unauthorized"));
            }
            var account = await unitOfWork
                .Repository<Account>()
                .FindByIdAsync(currentId.Value, cancellationToken);

            if (account == null)
            {
                return Result<GetMeResponse>.Failure(new NotFoundError("Không tìm thấy tài khoản"));
            }

            var response = account.ToGetMeResponse();
            return Result<GetMeResponse>.Success(response);
        }
    }
}
