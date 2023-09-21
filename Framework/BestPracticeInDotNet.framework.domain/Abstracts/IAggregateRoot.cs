using BestPracticeInDotNet.framework.Mediator.Abstracts;

namespace BestPracticeInDotNet.framework.DDD.Abstracts;

public interface IAggregateRoot<out TKey> : IEntity<TKey>
{
    long Version { get; set; }
    void ClearUncommittedEvents();
    IEnumerable<IDomainEvent> GetUncommittedEvents();
}