using BestPracticeInDotNet.Domain.Core.Errors;
using BestPracticeInDotNet.framework.Mediator.Extensions;
using FluentValidation;

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