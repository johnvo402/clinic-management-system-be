using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mediator;
using Serilog;

namespace CMS_BE.Application.Common.Behaviors
{
    public class PerformanceBehavior<TMessage, TResponse>(ILogger logger)
        : IPipelineBehavior<TMessage, TResponse>
        where TMessage : notnull, IMessage
    {
        private readonly Stopwatch timer = new();

        public async ValueTask<TResponse> Handle(
            TMessage message,
            MessageHandlerDelegate<TMessage, TResponse> next,
            CancellationToken cancellationToken
        )
        {
            timer.Start();

            TResponse response = await next(message, cancellationToken);

            timer.Stop();

            long elapsedMilliseconds = timer.ElapsedMilliseconds;

            string requestName = typeof(TMessage).Name;

            logger.Information(
                "\n\nApplication run {Name} request in ({ElapsedMilliseconds} milliseconds)\n\n",
                requestName,
                elapsedMilliseconds
            );

            return response;
        }
    }
}
