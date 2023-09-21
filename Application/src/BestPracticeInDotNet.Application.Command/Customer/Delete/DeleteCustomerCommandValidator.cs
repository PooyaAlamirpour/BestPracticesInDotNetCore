using FluentValidation;
using BestPracticeInDotNet.Domain.Generic.Errors;
using BestPracticeInDotNet.framework.Mediator.Extensions;

namespace BestPracticeInDotNet.Application.Command.Customer.Delete;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.Customer.Id.Empty);
    }
}