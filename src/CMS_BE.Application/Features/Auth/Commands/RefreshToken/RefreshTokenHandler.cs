using System.IdentityModel.Tokens.Jwt;
using CMS_BE.Application.ApiWrapper;
using CMS_BE.Application.Common.Extensions;
using CMS_BE.Application.Common.Interfaces.Token;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Application.Errors;
using CMS_BE.Domain.Aggregates.Auth;
using CMS_BE.Domain.Aggregates.Auth.Specifications;
using Mediator;

namespace CMS_BE.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenHandler(IUnitOfWork unitOfWork, ITokenFactory tokenFactory)
        : IRequestHandler<RefreshTokenCommand, Result<RefreshTokenResponse>>
    {
        public async ValueTask<Result<RefreshTokenResponse>> Handle(
            RefreshTokenCommand command,
            CancellationToken cancellationToken
        )
        {
            long nowUnixTimeMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            AccountToken? refresh = await unitOfWork
                .DynamicReadOnlyRepository<AccountToken>()
                .FindByConditionAsync(
                    new GetRefreshTokenSpecification(
                        command.RefreshToken!,
                        nowUnixTimeMilliseconds
                    ),
                    cancellationToken
                );

            if (refresh == null)
            {
                return Result<RefreshTokenResponse>.Failure(
                    new BadRequestError("Token không hợp lệ hoặc đã hết hạn.")
                );
            }

            string newRefreshToken = StringExtension.GenerateRandomString(64);

            var accesstokenExpiredTime = tokenFactory.AccesstokenExpiredTime;

            string accessToken = tokenFactory.CreateToken(
                [new(JwtRegisteredClaimNames.Sub, refresh.AccountId.ToString())],
                accesstokenExpiredTime
            );
            long refreshExpireTime = new DateTimeOffset(
                tokenFactory.RefreshtokenExpiredTime
            ).ToUnixTimeMilliseconds();

            refresh.Token = newRefreshToken;
            refresh.ExpiresAt = refreshExpireTime;

            try
            {
                _ = await unitOfWork.BeginTransactionAsync(cancellationToken);
                await unitOfWork.Repository<AccountToken>().UpdateAsync(refresh);
                await unitOfWork.SaveAsync(cancellationToken);
                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (System.Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }

            return Result<RefreshTokenResponse>.Success(
                new()
                {
                    AccessToken = accessToken,
                    RefreshToken = newRefreshToken,
                    ExpiresIn = new DateTimeOffset(accesstokenExpiredTime).ToUnixTimeMilliseconds(),
                }
            );
        }
    }
}
