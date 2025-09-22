using CMS_BE.Application.Common.Interfaces.Services;

namespace CMS_BE.Presentation.Middlewares
{
    public class AccountMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context, ICurrentAccount currentUser)
        {
            if (context.User?.Identity?.IsAuthenticated == true)
            {
                currentUser.SetClaimPrinciple(context.User);
            }

            currentUser.SetClientIp(context);

            await next.Invoke(context);
        }
    }
}
