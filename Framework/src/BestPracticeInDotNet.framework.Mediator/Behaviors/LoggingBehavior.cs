using System.Text.Json;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BestPracticeInDotNet.framework.Mediator.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var result = await next();
            if (result.IsError)
            {
                _logger.LogError($"{typeof(TRequest).Name} with " +
                                 $"{JsonSerializer.Serialize(request)} " +
                                 " is failed. Errors: " +
                                 $"{JsonSerializer.Serialize(result.Errors)}");
            }

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError($"{typeof(TRequest).Name} with " +
                             $"{JsonSerializer.Serialize(request)} " +
                             " is failed. Errors: " +
                             $"{JsonSerializer.Serialize(ex)}");
            throw;
        }
    }
}