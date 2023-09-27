using BestPracticeInDotNet.framework.DDD.Abstracts;
using MediatR;

namespace BestPracticeInDotNet.framework.DDD;

public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot<TId>, IAuditable
    where TId : notnull
{
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public long Version { get; set; }

    protected AggregateRoot(TId id) : base(id)
    {
    }
    
    public abstract void Apply(INotification @event);
    
}