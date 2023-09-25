using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Queries.User.Get;

public record GetUserQuery(string Email) : IRequest<ErrorOr<Domain.Core.User.User>>;