using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.Host.ValueObjects;

public class HostId : ValueObject<Guid>
{
    private HostId(Guid value)
    {
        this.Value = value;
    }

    public static HostId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<Guid> GetEqualityComponents()
    {
        yield return Value;
    }
}