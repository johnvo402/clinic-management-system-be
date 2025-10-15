using CMS_BE.Domain.Aggregates.Auth;
using CMS_BE.Domain.Aggregates.Auth.Enums;
using CMS_BE.Domain.Aggregates.Humans.Enums;

namespace CMS_BE.Application.Features.Auth.Common.Projections
{
    public class ProfileProjection
    {
        public Ulid Id { get; set; }
        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public Role Role { get; set; }
        public string FullName { get; set; } = default!;
        public Gender Gender { get; set; }
        public string? Email { get; set; }

        public virtual void MappingFrom(Account account)
        {
            Id = account.Id;
            Username = account.Username;
            PasswordHash = account.PasswordHash;
            Role = account.Role;
            FullName = account.FullName;
            Gender = account.Gender;
            Email = account.Email;
        }
    }
}
