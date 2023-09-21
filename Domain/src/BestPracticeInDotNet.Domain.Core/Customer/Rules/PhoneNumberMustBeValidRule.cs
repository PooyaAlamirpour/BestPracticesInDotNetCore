using BestPracticeInDotNet.framework.DDD.Abstracts;
using PhoneNumbers;

namespace BestPracticeInDotNet.Domain.Core.Customer.Rules;

public class PhoneNumberMustBeValidRule : IBusinessRule
{
    private readonly string _phoneNumber;
    public PhoneNumberMustBeValidRule(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }

    public bool HasValidRule()
    {
        try
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneNumberUtil.Parse(_phoneNumber, null);
            var isValid = phoneNumberUtil.IsValidNumber(phoneNumber);
            return isValid;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public string Message => $"The {_phoneNumber} number is not valid.";
}