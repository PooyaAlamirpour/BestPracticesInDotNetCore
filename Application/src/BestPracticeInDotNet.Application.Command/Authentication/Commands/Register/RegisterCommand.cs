using BestPracticeInDotNet.Application.Command.Authentication.Models;
using ErrorOr;
using MediatR;

namespace BestPracticeInDotNet.Application.Command.Authentication.Commands.Register;

public record RegisterCommand(string FirstName, string LastName, string Email, string Password) : 
    IRequest<ErrorOr<RegisterCommandResponse>>;
