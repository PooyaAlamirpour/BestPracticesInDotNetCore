namespace BestPracticeInDotNet.Application.Command.Authentication.Models;

public record RegisterCommandResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);