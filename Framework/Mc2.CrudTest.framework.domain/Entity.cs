using Mc2.CrudTest.framework.DDD.Abstracts;

namespace Mc2.CrudTest.framework.DDD;

public class Entity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set;  }
}