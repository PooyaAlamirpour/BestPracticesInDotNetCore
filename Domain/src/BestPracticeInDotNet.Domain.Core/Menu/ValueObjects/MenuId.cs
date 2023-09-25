using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.Menu.ValueObjects;

public class MenuId : ValueObject<Guid>
{
    private MenuId(Guid value)
    {
        this.Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<Guid> GetEqualityComponents()
    {
        yield return Value;
    }
}