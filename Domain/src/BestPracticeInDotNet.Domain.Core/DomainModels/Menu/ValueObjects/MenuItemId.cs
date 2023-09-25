using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Menu.ValueObjects;

public class MenuItemId : ValueObject<Guid>
{
    private MenuItemId(Guid value)
    {
        this.Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<Guid> GetEqualityComponents()
    {
        yield return Value;
    }
}