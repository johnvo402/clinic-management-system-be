using Ardalis.GuardClauses;
using CMS_BE.Domain.Aggregates.Auth.Enums;
using CMS_BE.Domain.Aggregates.Humans.Enums;
using CMS_BE.Domain.Common;
using Mediator;

namespace CMS_BE.Domain.Aggregates.Auth
{
    public class Account : AggregateRoot
    {
        public string Username { get; private set; } = default!;
        public string PasswordHash { get; private set; } = default!;
        public Role Role { get; private set; }
        public string FullName { get; private set; } = default!;
        public Gender Gender { get; set; }
        public string? Email { get; set; }

        public Account() { }

        public Account(string username, string passwordHash, Role role, string fullName)
        {
            FullName = Guard.Against.NullOrEmpty(fullName, nameof(FullName));
            Username = Guard.Against.NullOrEmpty(username, nameof(Username));
            PasswordHash = Guard.Against.NullOrEmpty(passwordHash, nameof(PasswordHash));
            Role = Guard.Against.EnumOutOfRange(role, nameof(Role));
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = Guard.Against.NullOrEmpty(newPasswordHash, nameof(newPasswordHash));
        }

        public ICollection<AccountToken>? AccountToken { get; set; } = [];

        protected override bool TryApplyDomainEvent(INotification domainEvent)
        {
            throw new NotImplementedException();
        }
    }
}
