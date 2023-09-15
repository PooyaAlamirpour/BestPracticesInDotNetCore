using Mc2.CrudTest.framework.DDD;
using Mc2.CrudTest.framework.DDD.Abstracts;

namespace Mc2.CrudTest.Infrastructure.Persistence.Entities;

public class EventEntity : Entity<Guid>, IAuditable
{
    public Guid AggregateId { get; set; }
    public string AggregateType { get; set; }
    public string Payload { get; set; } = string.Empty;
    public long Version { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}