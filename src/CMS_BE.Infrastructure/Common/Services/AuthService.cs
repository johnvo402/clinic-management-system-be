using CMS_BE.Application.Common.Interfaces.Services;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Domain.Aggregates.Auth;
using Microsoft.EntityFrameworkCore;

namespace CMS_BE.Infrastructure.Common.Services
{
    public class AuthService(IDbContext context) : IAuthService
    {
        private readonly DbSet<Account> accountDbSet = context.Set<Account>();
        public DbSet<Account> Account => accountDbSet;

        public async Task ChangePasswordAsync(Account account, string newPasswordHash)
        {
            account.ChangePassword(newPasswordHash);
            accountDbSet.Update(account);
            await context.SaveChangesAsync();
            return;
        }

        public async Task<bool> HasRoleAsync(Ulid accountId, List<string>? roleNames) =>
            await accountDbSet.AnyAsync(x =>
                x.Id == accountId && roleNames != null && roleNames.Contains(x.Role.ToString())
            );
    }
}
