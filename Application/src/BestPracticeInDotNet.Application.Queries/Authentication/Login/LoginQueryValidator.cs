using BestPracticeInDotNet.Domain.Core.Errors;
using BestPracticeInDotNet.framework.Mediator.Extensions;
using FluentValidation;

namespace BestPracticeInDotNet.Application.Queries.Authentication.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.User.Email.Empty);
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.User.Password.Empty);
    }
}