using System.Text.RegularExpressions;
using BestPracticeInDotNet.framework.DDD.Abstracts;

namespace BestPracticeInDotNet.Domain.Core.Customer.Rules;

public class EmailMustBeValidRule : IBusinessRule
{
    private readonly string _email;
    public EmailMustBeValidRule(string email)
    {
        _email = email;
    }

    public bool HasValidRule()
    {
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(_email, pattern);
    }

    public string Message => $"The email of {_email} is not valid.";
}