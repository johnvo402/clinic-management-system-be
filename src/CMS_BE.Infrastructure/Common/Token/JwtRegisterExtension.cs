using System.Text;
using CMS_BE.Application.Common.Interfaces.Token;
using CMS_BE.Application.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CMS_BE.Infrastructure.Common.Token
{
    public static class JwtRegisterExtension
    {
        public static IServiceCollection AddJwtAuth(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            services.Configure<JwtSettings>(
                config.GetSection($"SecuritySettings:{nameof(JwtSettings)}")
            );

            var jwtSettings = config
                .GetSection($"SecuritySettings:{nameof(JwtSettings)}")
                .Get<JwtSettings>();

            services.AddSingleton<ITokenFactory, TokenSecurityService>();

            return services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes(jwtSettings!.SecretKey!)
                        ),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                    };

                    bearer.IncludeErrorDetails = true;
                    bearer.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            return TokenErrorExtension.UnauthorizedException(
                                context,
                                !context.Response.HasStarted
                                    ? new UnauthorizedError("UNAUTHORIZED")
                                    : new UnauthorizedError("TOKEN_EXPIRED")
                            );
                        },
                        OnForbidden = context =>
                            TokenErrorExtension.ForbiddenException(
                                context,
                                new ForbiddenError("FORBIDDEN")
                            ),
                    };
                })
                .Services;
        }
    }
}
