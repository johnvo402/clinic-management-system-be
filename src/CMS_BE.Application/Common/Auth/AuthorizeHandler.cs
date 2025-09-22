using System.Text.Json;
using CMS_BE.Application.Common.Interfaces.Services;
using CMS_BE.Domain.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CMS_BE.Application.Common.Auth
{
    public class AuthorizeHandler(
        IServiceProvider serviceProvider,
        ICurrentAccount currentUser,
        IHttpContextAccessor _httpContextAccessor
    ) : AuthorizationHandler<AuthorizationRequirement>
    {
        private readonly IServiceProvider serviceProvider = serviceProvider;

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            AuthorizationRequirement requirement
        )
        {
            using var scope = serviceProvider.CreateScope();
            IAuthService accountManagerService =
                scope.ServiceProvider.GetRequiredService<IAuthService>();

            Ulid? userId = currentUser.Id;

            if (userId == null)
            {
                context.Fail(new AuthorizationFailureReason(this, "User is UnAuthenticated"));
                return;
            }

            try
            {
                string requirementJson = requirement.Requirement();
                if (string.IsNullOrEmpty(requirementJson))
                {
                    context.Succeed(requirement);
                    return;
                }

                AuthorizeModel? authorizeModel = SerializerExtension
                    .Deserialize<AuthorizeModel>(requirementJson)
                    .Object;

                if (authorizeModel?.Roles?.Count > 0)
                {
                    bool hasRole = await accountManagerService.HasRoleAsync(
                        (Ulid)userId,
                        authorizeModel.Roles
                    );
                    SuccessOrFailiureHandler(context, requirement, hasRole);

                    return;
                }
            }
            catch (JsonException)
            {
                // Log error if needed
                context.Fail(
                    new AuthorizationFailureReason(this, "Invalid authorization requirement format")
                );
                return;
            }

            await Task.CompletedTask;
        }

        private static void SuccessOrFailiureHandler(
            AuthorizationHandlerContext context,
            AuthorizationRequirement requirement,
            bool isSuccess = false
        )
        {
            if (!isSuccess)
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }
    }
}
