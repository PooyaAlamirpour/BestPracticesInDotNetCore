using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.Infrastructure.EventStore.Abstracts;

public interface IEventDispatcher
{
    Task DispatchAsync(IDomainEvent @event, CancellationToken cancellationToken = default);
}