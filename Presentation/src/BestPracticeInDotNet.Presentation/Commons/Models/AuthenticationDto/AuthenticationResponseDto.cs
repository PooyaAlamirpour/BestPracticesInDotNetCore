namespace BestPracticeInDotNet.Presentation.Contracts.Authentication;

public record AuthenticationResponseDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);
    