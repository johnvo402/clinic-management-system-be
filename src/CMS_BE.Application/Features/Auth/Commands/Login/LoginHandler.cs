using System.IdentityModel.Tokens.Jwt;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Extensions;
using CMS_BE.Application.Common.Interfaces.Token;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Errors;
using CMS_BE.Domain.Aggregates.Auth;
using CMS_BE.Domain.Aggregates.Auth.Specifications;
using Mediator;

namespace CMS_BE.Application.Features.Auth.Commands.Login
{
    public class LoginHandler(IUnitOfWork unitOfWork, ITokenFactory tokenFactory)
        : IRequestHandler<LoginCommand, Result<LoginResponse>>
    {
        public async ValueTask<Result<LoginResponse>> Handle(
            LoginCommand request,
            CancellationToken cancellationToken
        )
        {
            Account? account = await unitOfWork
                .DynamicReadOnlyRepository<Account>()
                .FindByConditionAsync(
                    new GetAccountByUsernameSpecification(request.Username!),
                    cancellationToken
                );
            if (account == null)
            {
                return Result<LoginResponse>.Failure(
                    new NotFoundError("Tài khoản không tồn tại trong hệ thống.")
                );
            }

            if (!Verify(request.Password, account.PasswordHash))
            {
                return Result<LoginResponse>.Failure(new BadRequestError("Mật khẩu không đúng."));
            }

            string refreshToken = StringExtension.GenerateRandomString(64);

            var accesstokenExpiredTime = tokenFactory.AccesstokenExpiredTime;

            string accessToken = tokenFactory.CreateToken(
                [new(JwtRegisteredClaimNames.Sub, account.Id.ToString())],
                accesstokenExpiredTime
            );
            long refreshExpireTime = new DateTimeOffset(
                tokenFactory.RefreshtokenExpiredTime
            ).ToUnixTimeSeconds();

            var userToken = new AccountToken()
            {
                ExpiresAt = refreshExpireTime,
                AccountId = account.Id,
                Token = refreshToken,
            };

            try
            {
                _ = await unitOfWork.BeginTransactionAsync(cancellationToken);
                await unitOfWork.Repository<AccountToken>().AddAsync(userToken, cancellationToken);
                await unitOfWork.SaveAsync(cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (System.Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }

            return Result<LoginResponse>.Success(
                new()
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresIn = new DateTimeOffset(accesstokenExpiredTime).ToUnixTimeSeconds(),
                }
            );
        }
    }
}
