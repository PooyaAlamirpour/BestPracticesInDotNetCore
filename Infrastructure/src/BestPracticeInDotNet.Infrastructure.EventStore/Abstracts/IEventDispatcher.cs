using MediatR;

namespace BestPracticeInDotNet.Infrastructure.EventStore.Abstracts;

public interface IEventDispatcher
{
    Task DispatchAsync(INotification @event, CancellationToken cancellationToken = default);
}