﻿using Mc2.CrudTest.Domain.Core.Customer.Rules;
using Mc2.CrudTest.framework.DDD;

namespace Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

public class PhoneNumber : ValueObject<PhoneNumber>
{
    private readonly string _phoneNumber;
    
    public string Value => _phoneNumber;

    private PhoneNumber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }

    public static PhoneNumber Of(string phoneNumber)
    {
        CheckRule(new PhoneNumberLengthMustBeValidRule(phoneNumber));
        CheckRule(new PhoneNumberMustBeValidRule(phoneNumber));
        
        return new PhoneNumber(phoneNumber);
    }
}