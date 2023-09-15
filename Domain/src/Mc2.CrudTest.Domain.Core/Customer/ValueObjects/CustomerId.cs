using Mc2.CrudTest.framework.DDD;

namespace Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

public class CustomerId : ValueObject<CustomerId>
{
    private CustomerId(Guid customerId)
    {
        this.Value = customerId;
    }

    public static CustomerId Of(Guid customerId) => new(customerId);
}