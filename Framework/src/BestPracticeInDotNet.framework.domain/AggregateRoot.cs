using BestPracticeInDotNet.framework.DDD.Abstracts;
using MediatR;

namespace BestPracticeInDotNet.framework.DDD;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot<TId>, IAuditable
    where TId : notnull
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    private readonly Queue<INotification> _uncommittedEvents = new();
    public long Version { get; set; }
    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();
    public IEnumerable<INotification> GetUncommittedEvents() => _uncommittedEvents;

    protected AggregateRoot(TId id) : base(id)
    {
    }
    
    public abstract void Apply(INotification @event);
    
    protected void RaiseEvent(INotification @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }
}