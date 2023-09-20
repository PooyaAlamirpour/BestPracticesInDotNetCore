using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.framework.DDD.Abstracts;

public interface IAggregateRoot<out TKey> : IEntity<TKey>
{
    long Version { get; set; }
    void ClearUncommittedEvents();
    IEnumerable<IDomainEvent> GetUncommittedEvents();
}