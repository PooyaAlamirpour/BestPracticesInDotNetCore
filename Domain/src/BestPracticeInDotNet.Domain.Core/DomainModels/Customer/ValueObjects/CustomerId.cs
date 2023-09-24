﻿using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Customer.ValueObjects;

public class CustomerId : ValueObject<CustomerId>
{
    private CustomerId(Guid customerId)
    {
        // this.Value = customerId;
    }

    public static CustomerId Of(Guid customerId) => new(customerId);
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}