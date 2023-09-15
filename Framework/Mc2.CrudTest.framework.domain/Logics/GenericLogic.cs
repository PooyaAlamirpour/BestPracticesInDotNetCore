using Mc2.CrudTest.framework.DDD.Abstracts;
using Mc2.CrudTest.framework.DDD.Exceptions;

namespace Mc2.CrudTest.framework.DDD.Logics;

public abstract class GenericLogic
{
    protected static void CheckRule(IBusinessRule rule)
    {
        if (!rule.HasValidRule())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}