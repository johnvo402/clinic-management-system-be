using CMS_BE.Domain.Aggregates.Auth;

namespace CMS_BE.Application.Common.Interfaces.Services
{
    public interface IAuthService
    {
        Task ChangePasswordAsync(Account account, string newPasswordHash);

        Task<bool> HasRoleAsync(Ulid accountId, List<string>? role);
    }
}
