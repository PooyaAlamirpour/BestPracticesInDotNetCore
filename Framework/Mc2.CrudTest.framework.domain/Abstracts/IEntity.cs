namespace Mc2.CrudTest.framework.DDD.Abstracts;

public interface IEntity<out TKey>
{
    TKey Id { get; }
}