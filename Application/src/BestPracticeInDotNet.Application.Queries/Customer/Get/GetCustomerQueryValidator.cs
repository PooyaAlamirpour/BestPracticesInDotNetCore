using FluentValidation;

namespace BestPracticeInDotNet.Application.Queries.Customer.Get;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator()
    {
    }
}