using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.framework.DDD;

public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>, IDomainEventEntity
    where TId : notnull
{
    private readonly Queue<IDomainEvent> _uncommittedEvents = new();
    public void ClearUncommittedEvents() => _uncommittedEvents.Clear();
    public IEnumerable<IDomainEvent> GetUncommittedEvents() => _uncommittedEvents;
    public IReadOnlyList<IDomainEvent> DomainEvents => _uncommittedEvents.ToArray().AsReadOnly();
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

    protected void RaiseEvent(IDomainEvent @event)
    {
        _uncommittedEvents.Enqueue(@event);    
    }
    
    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}