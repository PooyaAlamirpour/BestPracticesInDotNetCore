namespace BestPracticeInDotNet.Application.Queries.Authentication.Login;

public record LoginQueryResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);