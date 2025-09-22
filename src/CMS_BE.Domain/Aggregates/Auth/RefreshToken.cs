using CMS_BE.Domain.Common;

namespace CMS_BE.Domain.Aggregates.Auth
{
    public class AccountToken : BaseEntity
    {
        public Ulid AccountId { get; set; }
        public string Token { get; set; } = default!;
        public long ExpiresAt { get; set; }
    }
}
