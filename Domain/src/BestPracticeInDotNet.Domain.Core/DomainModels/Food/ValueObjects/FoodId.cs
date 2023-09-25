using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Food.ValueObjects;

public class FoodId : ValueObject<Guid>
{
    private FoodId(Guid value)
    {
        this.Value = value;
    }

    public static FoodId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<Guid> GetEqualityComponents()
    {
        yield return Value;
    }
}