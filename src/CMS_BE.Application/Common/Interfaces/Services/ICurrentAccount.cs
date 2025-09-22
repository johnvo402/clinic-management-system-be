using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Application.Common.Interfaces.Services
{
    public interface ICurrentAccount
    {
        public Ulid? Id { get; }

        public string? ClientIp { get; }

        void SetClientIp(HttpContext httpContext);
        void SetClaimPrinciple(ClaimsPrincipal user);
    }
}
