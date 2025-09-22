using System.Diagnostics;
using CMS_BE.Application.ApiWrapper;
using Mediator;
using Serilog;

namespace CMS_BE.Application.Common.Behaviors
{
    public sealed class ErrorLoggingBehavior<TMessage, TResponse>(ILogger logger)
        : MessageExceptionHandler<TMessage, TResponse>
        where TMessage : notnull, IMessage
    {
        protected override ValueTask<ExceptionHandlingResult<TResponse>> Handle(
            TMessage message,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            logger.Error(
                "\n\n Server {exception} error has {@trace}  error is with message '{Message}'\n {StackTrace}\n at {DatetimeUTC} \n",
                exception.GetType().Name,
                new TraceLogging()
                {
                    TraceId = Activity.Current?.TraceId.ToString(),
                    SpanId = Activity.Current?.SpanId.ToString(),
                },
                exception.Message,
                exception.StackTrace?.TrimStart(),
                DateTimeOffset.UtcNow
            );

            return NotHandled;
        }
    }
}
