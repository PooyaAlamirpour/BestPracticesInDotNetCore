using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.Infrastructure.EventStore.Abstracts;

public interface IEventDispatcher
{
    Task DispatchAsync(IDomainEvent @event, CancellationToken cancellationToken = default);
}