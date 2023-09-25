using BestPracticeInDotNet.framework.DDD;
using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.Infrastructure.EventStore.Entities;

public class EventEntity : Entity<Guid>, IAuditable
{
    public Guid AggregateId { get; set; }
    public string AggregateType { get; set; }
    public string Payload { get; set; } = string.Empty;
    public long Version { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public EventEntity(Guid id) : base(id)
    {
    }
}