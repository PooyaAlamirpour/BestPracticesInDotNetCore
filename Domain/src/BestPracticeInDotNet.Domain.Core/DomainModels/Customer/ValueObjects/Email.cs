using BestPracticeInDotNet.Domain.Core.DomainModels.Customer.Rules;
using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Customer.ValueObjects;

public class Email : ValueObject<Email>
{
    private readonly string _email;
    
    public string Value => _email;

    private Email(string email)
    {
        _email = email;
    }

    public static Email Of(string email)
    {
        CheckRule(new EmailMustBeValidRule(email));
        return new Email(email);
    }
}