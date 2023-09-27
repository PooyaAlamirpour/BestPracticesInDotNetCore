using BestPracticeInDotNet.Domain.SubDomain.Errors;
using BestPracticeInDotNet.framework.Mediator.Extensions;
using FluentValidation;

namespace BestPracticeInDotNet.Application.Command.Customer.Commands.Create;

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