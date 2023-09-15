using Mc2.CrudTest.framework.DDD.Abstracts;
using Mc2.CrudTest.framework.Mediator.Abstracts;

namespace Mc2.CrudTest.framework.DDD;

public abstract class AggregateRoot<TKey> : Entity<TKey>,  IAggregateRoot<TKey>, IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    private readonly Queue<IDomainEvent> _uncommittedEvents = new();
    public long Version { get; set; }
    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();
    public IEnumerable<IDomainEvent> GetUncommittedEvents() => _uncommittedEvents;

    public abstract void Apply(IDomainEvent @event);
    
    protected void RaiseEvent(IDomainEvent @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }
}