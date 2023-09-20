using Mc2.CrudTest.Domain.Core.Customer.Rules;
using Mc2.CrudTest.framework.DDD;

namespace Mc2.CrudTest.Domain.Core.Customer.ValueObjects;

public class DateOfBirthdate : ValueObject<Email>
{
    private readonly DateOnly _dateOfBirth;
    
    public DateOnly Value => _dateOfBirth;

    private DateOfBirthdate(string dateOfBirth)
    {
        DateOnly.TryParse(dateOfBirth, out DateOnly parsedDatetime);
        _dateOfBirth = parsedDatetime;
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }

    public static DateOfBirthdate Of(string dateOfBirth)
    {
        CheckRule(new DateOfBirthMustBeValidRule(dateOfBirth));
        return new DateOfBirthdate(dateOfBirth);
    }
}