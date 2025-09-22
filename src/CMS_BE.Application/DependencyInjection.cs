using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CMS_BE.Application.Common.Auth;
using CMS_BE.Application.Common.Behaviors;
using FluentValidation;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CMS_BE.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencies(
            this IServiceCollection services
        )
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

            return services
                .AddMediator(option => option.ServiceLifetime = ServiceLifetime.Scoped)
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(ErrorLoggingBehavior<,>))
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>))
                .AddValidatorsFromAssembly(currentAssembly)
                .AddSingleton<IAuthorizationPolicyProvider, AuthorizePolicyProvider>()
                .AddScoped<IAuthorizationHandler, AuthorizeHandler>();
        }
    }
}
