using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.framework.DDD;

public interface IDomainEventEntity
{
    void ClearUncommittedEvents();
    IEnumerable<IDomainEvent> GetUncommittedEvents();
}