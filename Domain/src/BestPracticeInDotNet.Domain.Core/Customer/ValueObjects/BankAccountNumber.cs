using Mc2.CrudTest.Domain.Core.Customer.Rules;
using Mc2.CrudTest.framework.DDD;

namespace Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

public class BankAccountNumber : ValueObject<BankAccountNumber>
{
    private readonly string _bankAccountNumber;
    
    public string Value => _bankAccountNumber;

    private BankAccountNumber(string bankAccountNumber)
    {
        _bankAccountNumber = bankAccountNumber;
    }

    public static BankAccountNumber Of(string bankAccountNumber)
    {
        CheckRule(new BankAccountNumberMustBeValidRule(bankAccountNumber));
        return new BankAccountNumber(bankAccountNumber);
    }
}