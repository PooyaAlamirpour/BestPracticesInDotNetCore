namespace BestPracticeInDotNet.Application.Services.Authentication.ResponseModels;

public record AuthenticationResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);