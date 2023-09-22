using BestPracticeInDotNet.framework.DDD.Abstracts;
using MediatR;

namespace BestPracticeInDotNet.framework.DDD;

public abstract class AggregateRoot<TKey> : Entity<TKey>,  IAggregateRoot<TKey>, IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    private readonly Queue<INotification> _uncommittedEvents = new();
    public long Version { get; set; }
    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();
    public IEnumerable<INotification> GetUncommittedEvents() => _uncommittedEvents;

    public abstract void Apply(INotification @event);
    
    protected void RaiseEvent(INotification @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }
}