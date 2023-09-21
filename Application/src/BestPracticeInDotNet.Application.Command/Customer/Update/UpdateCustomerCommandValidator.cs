using BestPracticeInDotNet.Domain.Generic.Errors;
using BestPracticeInDotNet.framework.Mediator.Extensions;
using FluentValidation;

namespace BestPracticeInDotNet.Application.Command.Customer.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.Customer.Id.Empty);
    }
}