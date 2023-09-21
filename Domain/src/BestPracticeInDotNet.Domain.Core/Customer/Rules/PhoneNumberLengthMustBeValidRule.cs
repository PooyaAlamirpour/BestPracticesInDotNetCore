using BestPracticeInDotNet.framework.DDD.Abstracts;
using PhoneNumbers;

namespace BestPracticeInDotNet.Domain.Core.Customer.Rules;

public class PhoneNumberLengthMustBeValidRule : IBusinessRule
{
    private readonly string _phoneNumber;
    public PhoneNumberLengthMustBeValidRule(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }

    public bool HasValidRule()
    {
        // This is the fast way of checking a phone number based on length.
        try
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneNumberUtil.Parse(_phoneNumber, null);
            var isValid = phoneNumberUtil.IsPossibleNumber(phoneNumber);
            return isValid;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public string Message => $"The length of {_phoneNumber} is not valid.";
}