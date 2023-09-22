using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Authentication.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : 
    IRequest<ErrorOr<RegisterCommandResponse>>;
