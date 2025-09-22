using Serilog;

namespace CMS_BE.Presentation.Extensions
{
    public static class SerialogExtension
    {
        public static void AddSerialogs(this WebApplicationBuilder builder)
        {
            LoggerConfiguration loggerConfiguration =
                new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration);

            loggerConfiguration.WriteTo.File(
                path: $"../../logs/log-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 7,
                fileSizeLimitBytes: 10_000_000,
                rollOnFileSizeLimit: true,
                shared: true,
                flushToDiskInterval: TimeSpan.FromSeconds(1)
            );

            Log.Logger = loggerConfiguration.CreateLogger();

            builder.Host.UseSerilog(Log.Logger);

            builder.Services.AddSingleton(Log.Logger);
        }
    }
}
