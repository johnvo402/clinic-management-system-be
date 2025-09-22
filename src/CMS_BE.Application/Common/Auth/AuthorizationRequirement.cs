using Microsoft.AspNetCore.Authorization;

namespace CMS_BE.Application.Common.Auth
{
    public class AuthorizationRequirement(string requirement) : IAuthorizationRequirement
    {
        private readonly string requirement = requirement;

        public string Requirement() => requirement[AuthorizePolicy.POLICY_PREFIX.Length..];
    }
}
