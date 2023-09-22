using BestPracticeInDotNet.Domain.Core.Errors;
using BestPracticeInDotNet.framework.Mediator.Extensions;
using FluentValidation;

namespace BestPracticeInDotNet.Application.Queries.User.Get;

public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
{
    public GetUserQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithError(Errors.User.Email.Empty);
    }
}