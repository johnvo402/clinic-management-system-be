using System.Security.Claims;
using CMS_BE.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace CMS_BE.Infrastructure.Common.Services
{
    public class CurrentAccountService : ICurrentAccount
    {
        public Ulid? Id { get; private set; }

        public string? ClientIp { get; private set; }

        public void SetClaimPrinciple(ClaimsPrincipal user)
        {
            if (user?.Identity?.IsAuthenticated != true)
                return;
            string? id = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrWhiteSpace(id))
            {
                Id = Ulid.Parse(id);
            }
            else
            {
                Id = null;
            }
        }

        public void SetClientIp(HttpContext httpContext)
        {
            ClientIp = httpContext.Connection.RemoteIpAddress?.ToString();
        }
    }
}
