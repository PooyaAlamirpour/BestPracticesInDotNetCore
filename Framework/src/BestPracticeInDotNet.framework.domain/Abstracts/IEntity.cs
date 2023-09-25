namespace BestPracticeInDotNet.framework.DDD.Abstracts;

public interface IEntity<out TKey>
{
    TKey Id { get; }
}