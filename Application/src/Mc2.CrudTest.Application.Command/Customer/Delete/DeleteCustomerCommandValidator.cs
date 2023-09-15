using FluentValidation;
using Mc2.CrudTest.Domain.Generic.Errors;
using Mc2.CrudTest.framework.Mediator.Extensions;

namespace Mc2.CrudTest.Application.Command.Customer.Delete;

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