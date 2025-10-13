using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using CMS_BE.Application;
using CMS_BE.Infrastructure;
using CMS_BE.Infrastructure.Data.Initializer;
using CMS_BE.Presentation.Converters;
using CMS_BE.Presentation.Extensions;
using CMS_BE.Presentation.Middlewares;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
#region main dependencies
builder.AddConfiguration();
builder
    .Services.AddControllers()
    .AddJsonOptions(option =>
    {
        option.JsonSerializerOptions.Converters.Add(new DatetimeConverter());
        option.JsonSerializerOptions.Converters.Add(new DateTimeOffsetConvert());
        option.JsonSerializerOptions.Converters.Add(
            new Cysharp.Serialization.Json.UlidJsonConverter()
        );
        option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

services.AddErrorDetails();
services.AddSwagger(configuration);
builder.AddSerialogs();
services.AddHealthChecks();
services.AddDatabaseHealthCheck(configuration);
services.AddHttpContextAccessor();
#endregion

#region layers dependencies
services.AddInfrastructureDependencies(configuration, builder.Environment.EnvironmentName);
services.AddApplicationDependencies();
#endregion
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(
        "customPolicy",
        opt =>
        {
            opt.PermitLimit = 100;
            opt.Window = TimeSpan.FromSeconds(10);
            opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            opt.QueueLimit = 50;
            opt.AutoReplenishment = true;
        }
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }
    );
});

try
{
    Log.Logger.Information("Application is starting....");
    var app = builder.Build();

    app.MapHealthChecks(
        "/api/health",
        new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse }
    );

    bool isDevelopment = app.Environment.IsDevelopment();
    bool isStaging = app.Environment.IsStaging();
    bool isProduction = app.Environment.IsProduction();

    if (isDevelopment)
    {
        app.UseSwagger();
        app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            x.RoutePrefix = "docs";
            x.ConfigObject.PersistAuthorization = true;
        });
        app.AddLog(Log.Logger, "docs", "/api/health");
    }
    app.UseCors("AllowFrontend");
    app.UseStatusCodePages();
    app.UseAuthentication();
    app.CurrentAccount();
    app.UseAuthorization();
    app.UseExceptionHandler();
    app.MapControllers();
    app.ApplyMigrations();
    using var scope = app.Services.CreateScope();
    var serviceProvider = scope.ServiceProvider;

    await DbInitializer.InitializeAsync(serviceProvider);
    Log.Logger.Information(
        "Application is launching with {environment}",
        app.Environment.EnvironmentName
    );
    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Fatal("Application has launched fail with error {error}", ex.Message);
}
finally
{
    Log.CloseAndFlush();
}

public partial class Program { }
