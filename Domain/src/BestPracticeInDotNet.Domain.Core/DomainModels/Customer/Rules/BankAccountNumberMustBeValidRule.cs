using System.Text.RegularExpressions;
using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.DomainModels.Customer.Rules;

public class BankAccountNumberMustBeValidRule : IBusinessRule
{
    private readonly string _bankAccountNumber;

    public BankAccountNumberMustBeValidRule(string bankAccountNumber)
    {
        _bankAccountNumber = bankAccountNumber;
    }

    public bool HasValidRule()
    {
        string pattern = @"^[0-9]{9,16}$"; 
        return Regex.IsMatch(_bankAccountNumber, pattern);
    }

    public string Message => $"Bank account of {_bankAccountNumber} is not valid.";
}