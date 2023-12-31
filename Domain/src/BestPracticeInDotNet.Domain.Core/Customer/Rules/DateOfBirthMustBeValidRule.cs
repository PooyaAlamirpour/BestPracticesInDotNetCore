﻿using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Customer.Rules;

public class DateOfBirthMustBeValidRule : IBusinessRule
{
    private readonly string _birthdate;

    public DateOfBirthMustBeValidRule(string birthdate)
    {
        _birthdate = birthdate;
    }

    public bool HasValidRule()
    {
        var isValid = DateOnly.TryParse(_birthdate, out DateOnly parsedDatetime);
        return isValid;
    }

    public string Message => $"The birthdate {_birthdate} is not valid.";
}