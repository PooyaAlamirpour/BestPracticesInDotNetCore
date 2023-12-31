﻿using BestPracticeInDotNet.Domain.Core.Customer.Rules;
using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;

public class DateOfBirthdate : ValueObject<Email>
{
    private readonly DateOnly _dateOfBirth;
    
    public DateOnly Value => _dateOfBirth;
    public override IEnumerable<Email> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

    private DateOfBirthdate(string dateOfBirth)
    {
        DateOnly.TryParse(dateOfBirth, out DateOnly parsedDatetime);
        _dateOfBirth = parsedDatetime;
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }

    public static DateOfBirthdate Of(string dateOfBirth)
    {
        CheckRule(new DateOfBirthMustBeValidRule(dateOfBirth));
        return new DateOfBirthdate(dateOfBirth);
    }
}