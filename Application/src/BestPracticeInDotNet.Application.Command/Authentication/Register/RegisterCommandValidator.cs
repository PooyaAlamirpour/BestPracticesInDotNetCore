using BestPracticeInDotNet.Domain.SubDomain.Errors;
using BestPracticeInDotNet.framework.Mediator.Extensions;
using FluentValidation;

namespace BestPracticeInDotNet.Application.Command.Authentication.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.User.Email.Empty);
        
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.User.FirstName.Empty);
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.User.LastName.Empty);
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.User.Password.Empty);
    }
}