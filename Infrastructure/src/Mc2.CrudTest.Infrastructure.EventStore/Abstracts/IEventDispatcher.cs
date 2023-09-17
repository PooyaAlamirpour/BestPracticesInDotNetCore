using MediatR;

namespace Mc2.CrudTest.framework.Mediator.Abstracts;

public interface IEventDispatcher
{
    Task DispatchAsync(IDomainEvent @event, CancellationToken cancellationToken = default);
}