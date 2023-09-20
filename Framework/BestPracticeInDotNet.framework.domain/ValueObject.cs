using Mc2.CrudTest.framework.DDD.Logics;

namespace Mc2.CrudTest.framework.DDD;

public class ValueObject<TKey> : GenericLogic
{
    public Guid Value { get; set; }
}