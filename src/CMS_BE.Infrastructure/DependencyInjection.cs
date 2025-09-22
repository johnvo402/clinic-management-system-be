using CMS_BE.Application.Common.Interfaces.Services;
using CMS_BE.Application.Common.Interfaces.UnitOfWorks;
using CMS_BE.Infrastructure.Common.Services;
using CMS_BE.Infrastructure.Common.Token;
using CMS_BE.Infrastructure.Common.UnitOfWork;
using CMS_BE.Infrastructure.Data;
using CMS_BE.Infrastructure.Data.Interceptors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Npgsql;

namespace CMS_BE.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDependencies(
            this IServiceCollection services,
            IConfiguration configuration,
            string? environmentName = "Development"
        )
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.Configure<DatabaseSettings>(options =>
                configuration.GetSection(nameof(DatabaseSettings)).Bind(options)
            );

            services.TryAddSingleton<IValidateOptions<DatabaseSettings>, ValidateDatabaseSetting>();

            services.AddSingleton(sp =>
            {
                var databaseSettings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                string connectionString = databaseSettings.DatabaseConnection!;
                return new NpgsqlDataSourceBuilder(connectionString).EnableDynamicJson().Build();
            });

            services
                .AddScoped<IDbContext, TheDbContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddSingleton<UpdateAuditableEntityInterceptor>()
                .AddSingleton<DispatchDomainEventInterceptor>()
                .AddScoped<IActionAccessorService, ActionAccessorService>();

            if (environmentName!.CompareTo("Development") == 0)
            {
                services.AddDbContext<TheDbContext>(
                    (sp, options) =>
                    {
                        NpgsqlDataSource npgsqlDataSource =
                            sp.GetRequiredService<NpgsqlDataSource>();
                        options
                            .UseNpgsql(npgsqlDataSource)
                            .AddInterceptors(
                                sp.GetRequiredService<UpdateAuditableEntityInterceptor>(),
                                sp.GetRequiredService<DispatchDomainEventInterceptor>()
                            );
                    }
                );
            }
            else
            {
                services.AddDbContextPool<TheDbContext>(
                    (sp, options) =>
                    {
                        NpgsqlDataSource npgsqlDataSource =
                            sp.GetRequiredService<NpgsqlDataSource>();
                        options
                            .UseNpgsql(npgsqlDataSource)
                            .AddInterceptors(
                                sp.GetRequiredService<UpdateAuditableEntityInterceptor>(),
                                sp.GetRequiredService<DispatchDomainEventInterceptor>()
                            );
                    }
                );
            }

            services
                .AddScoped<IAuthService, AuthService>()
                .AddSingleton<ICurrentAccount, CurrentAccountService>()
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddJwtAuth(configuration);

            return services;
        }
    }
}
