using CMS_BE.Domain.Specifications;
using CMS_BE.Domain.Specifications.Builders;

namespace CMS_BE.Domain.Aggregates.Auth.Specifications
{
    public class GetRefreshTokenSpecification : Specification<AccountToken>
    {
        public GetRefreshTokenSpecification(string token, long nowUnixTimeMilliseconds)
        {
            Query
                .Where(x => x.Token == token && x.ExpiresAt >= nowUnixTimeMilliseconds)
                .AsNoTracking();
        }
    }
}
