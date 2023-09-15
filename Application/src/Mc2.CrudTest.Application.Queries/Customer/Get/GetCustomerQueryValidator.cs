using FluentValidation;

namespace Mc2.CrudTest.Application.Queries.Customer.Get;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
    }
}