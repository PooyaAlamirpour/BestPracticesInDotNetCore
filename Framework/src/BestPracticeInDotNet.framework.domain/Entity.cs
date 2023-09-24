using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.framework.DDD;

public class Entity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set;  }
}