using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;

public class CustomerId : ValueObject<Guid>
{
    private CustomerId(Guid customerId)
    {
        this.Value = customerId;
    }

    public static CustomerId Of(Guid customerId) => new(customerId);
    public override IEnumerable<Guid> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}