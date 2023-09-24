using BestPracticeInDotNet.framework.DDD.Logics;

namespace BestPracticeInDotNet.framework.DDD;

public class ValueObject<TKey> : GenericLogic
{
    public Guid Value { get; set; }
}