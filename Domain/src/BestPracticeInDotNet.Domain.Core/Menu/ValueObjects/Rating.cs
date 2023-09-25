using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.Menu.ValueObjects;

public class Rating : ValueObject<int>
{
    public override IEnumerable<int> GetEqualityComponents()
    {
        yield return Value;
    }
}