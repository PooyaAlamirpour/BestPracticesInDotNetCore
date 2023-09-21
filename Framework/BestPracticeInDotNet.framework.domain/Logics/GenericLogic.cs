using BestPracticeInDotNet.framework.DDD.Abstracts;
using BestPracticeInDotNet.framework.DDD.Exceptions;

namespace BestPracticeInDotNet.framework.DDD.Logics;

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