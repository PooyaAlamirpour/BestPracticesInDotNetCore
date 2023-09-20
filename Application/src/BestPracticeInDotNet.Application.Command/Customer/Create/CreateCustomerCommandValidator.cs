using FluentValidation;
using Mc2.CrudTest.Domain.Generic.Errors;
using Mc2.CrudTest.framework.Mediator.Extensions;

namespace Mc2.CrudTest.Application.Command.Customer.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Firstname)
            .NotEmpty()
            .WithError(Errors.Customer.Firstname.Empty);

        RuleFor(x => x.Lastname)
            .NotEmpty()
            .WithError(Errors.Customer.Lastname.Empty);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithError(Errors.Customer.Email.Empty);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithError(Errors.Customer.PhoneNumber.Empty);

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithError(Errors.Customer.DateOfBirth.Empty);
    }
}