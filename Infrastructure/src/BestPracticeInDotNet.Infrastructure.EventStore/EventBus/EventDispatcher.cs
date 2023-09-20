using Mc2.CrudTest.framework.Mediator.Abstracts;
using Mc2.CrudTest.Infrastructure.EventStore.Abstracts;
using MediatR;

namespace Mc2.CrudTest.Infrastructure.EventStore.EventBus;

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