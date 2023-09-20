using Mc2.CrudTest.Domain.Core.Customer.Rules;
using Mc2.CrudTest.framework.DDD;

namespace Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

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