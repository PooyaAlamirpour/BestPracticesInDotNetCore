using BestPracticeInDotNet.Domain.Core.Customer.Rules;
using BestPracticeInDotNet.framework.DDD;

namespace BestPracticeInDotNet.Domain.Core.Customer.ValueObjects;

public class BankAccountNumber : ValueObject<BankAccountNumber>
{
    private readonly string _bankAccountNumber;
    
    public string Value => _bankAccountNumber;
    public override IEnumerable<BankAccountNumber> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }

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