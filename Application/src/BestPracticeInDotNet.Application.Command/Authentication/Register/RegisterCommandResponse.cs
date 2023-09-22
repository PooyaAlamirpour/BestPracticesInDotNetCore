namespace BestPracticeInDotNet.Application.Command.Authentication.Register;

public record RegisterCommandResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);