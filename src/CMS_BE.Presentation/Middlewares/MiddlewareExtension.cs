namespace CMS_BE.Presentation.Middlewares
{
    public static class MiddlewareExtension
    {
        public static void CurrentAccount(this IApplicationBuilder app)
        {
            app.UseMiddleware<AccountMiddleware>();
        }
    }
}
