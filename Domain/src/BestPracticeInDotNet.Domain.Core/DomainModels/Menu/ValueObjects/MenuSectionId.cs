using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Menu.ValueObjects;

public class MenuSectionId : ValueObject<Guid>
{
    private MenuSectionId(Guid value)
    {
        this.Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<Guid> GetEqualityComponents()
    {
        yield return Value;
    }
}