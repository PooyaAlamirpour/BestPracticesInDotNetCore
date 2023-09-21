using BestPracticeInDotNet.framework.Mediator.Abstracts;
using BestPracticeInDotNet.Infrastructure.EventStore.Abstracts;
using MediatR;

namespace BestPracticeInDotNet.Infrastructure.EventStore.EventBus;

public class EventDispatcher : IEventDispatcher
{
    private readonly IPublisher _eventPublisher;

    public EventDispatcher(IPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }

    public async Task DispatchAsync(IDomainEvent @event, CancellationToken cancellationToken = default)
    {
        await _eventPublisher.Publish(@event, cancellationToken);
    }
}