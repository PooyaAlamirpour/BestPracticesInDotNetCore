using BestPracticeInDotNet.Domain.Core.Customer.Rules;
using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;

public class PhoneNumber : ValueObject<PhoneNumber>
{
    private readonly string _phoneNumber;
    
    public string Value => _phoneNumber;
    public override IEnumerable<PhoneNumber> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

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